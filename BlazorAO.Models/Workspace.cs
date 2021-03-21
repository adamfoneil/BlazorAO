﻿using BlazorAO.Models.Conventions;
using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorAO.Models
{
    /// <summary>
    /// top-level container of a customer's data in a multi-tenant system
    /// </summary>
    public class Workspace : BaseTable
    {
        [Key]
        [MaxLength(50)]        
        public string Name { get; set; }

        public int NextInvoice { get; set; } = 1000;

        /// <summary>
        /// day of the week, as reported by T-SQL DATEPART(dw when pay periods end
        /// </summary>
        public int PayPeriodEndDay { get; set; }

        /// <summary>
        /// number of weeks in pay period
        /// </summary>
        public int PayPeriodWeeks { get; set; }

        /// <summary>
        /// Azure blob storage connection
        /// </summary>
        [MaxLength(255)]
        public string StorageConnectionString { get; set; }

        [MaxLength(50)]
        public string StorageContainer { get; set; }
    }
}
