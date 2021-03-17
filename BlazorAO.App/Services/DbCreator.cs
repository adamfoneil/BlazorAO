﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.SqlClient;
using ModelSync.Abstract;
using ModelSync.Models;
using ModelSync.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorAO.Services
{
    public class DbCreator
    {
        private readonly string _connectionString;
        private readonly DataModel _dataModel;
        private readonly IWebHostEnvironment _environment;

        public DbCreator(string connectionString, DataModel dataModel, IWebHostEnvironment environment)
        {
            _connectionString = connectionString;
            _dataModel = dataModel;
            _environment = environment;
        }

        public async Task<(bool success, string message)> DbExistsAsync()
        {            
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    await cn.OpenAsync();
                    return (true, null);
                }
            }
            catch (Exception exc)
            {
                return (false, exc.Message);
            }
        }

        public async Task<bool> HasUpdatesAsync()
        {
            var commands = await GetUpdatesAsync();
            return commands.Any();
        }

        public async Task<(bool success, string message)> UpdataDatabaseAsync()
        {
            try
            {                
                var commands = (await GetUpdatesAsync()).ToArray();
                if (!commands.Any())
                {
                    return (true, "No updates to apply.");
                }

                using (var cn = new SqlConnection(_connectionString))
                {
                    await new SqlServerDialect().ExecuteAsync(cn, commands);
                }                    
                
                return (true, null);
            }
            catch (Exception exc)
            {
                return (false, exc.Message);
            }
        }

        private async Task<IEnumerable<ScriptAction>> GetUpdatesAsync()
        {                        
            using (var cn = new SqlConnection(_connectionString))
            {
                var dbModel = await DataModel.FromSqlServerAsync(cn);
                var diff = DataModel.Compare(_dataModel, dbModel);
                var exclude = GetModelSyncExclusions();
                return diff.Where(action => !exclude.Contains(action.GetExcludeAction()));
            }
        }

        /// <summary>
        /// don't drop AspNet* built-in tables and anything else manually excluded by ModelSync
        /// </summary>        
        private IEnumerable<ExcludeAction> GetModelSyncExclusions()
        {
            var fileName = Path.Combine(_environment.ContentRootPath, "wwwroot", "data", "ModelSync.exclude.json");
            var json = File.ReadAllText(fileName);

            using (var doc = JsonDocument.Parse(json))
            {
                var items = doc.RootElement.GetProperty("Actions").GetProperty("merge");
                foreach (var item in items.EnumerateArray())
                {
                    var itemJson = item.GetRawText();
                    yield return JsonSerializer.Deserialize<ExcludeAction>(itemJson);
                }
            }               
        }
    }
}