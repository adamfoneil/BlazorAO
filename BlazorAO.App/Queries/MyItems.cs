using Dapper.QX.Abstract;
using Dapper.QX.Attributes;
using Dapper.QX.Interfaces;
using System;
using System.Collections.Generic;

namespace BlazorAO.App.Queries
{
    public class MyItemsResult
    {
        public int Id { get; set; }
        public int WorkspaceId { get; set; }
        public string Name { get; set; }
        public int TypeId { get; set; }
        public int QuantityOnHand { get; set; }
        public decimal? SalePrice { get; set; }
        public decimal? Cost { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }
        public string ItemType { get; set; }
    }

    public enum MyItemsSortOptions
    {
        Name,
        QuantityOnHand
    }

    public class MyItems : TestableQuery<MyItemsResult>
    {
        public MyItems() : base(
            @"SELECT
                [i].*,
                [it].[Name] AS [ItemType]
            FROM
                [dbo].[Item] [i]
                INNER JOIN [dbo].[ItemType] [it] ON [i].[TypeId]=[it].[Id]
            WHERE
                [i].[WorkspaceId]=@workspaceId {andWhere}
            ORDER BY
                {orderBy} {offset}")
        {
        }

        public int WorkspaceId { get; set; }

        [Where("[i].[IsActive]=@isActive")]
        public bool? IsActive { get; set; } = true;

        [Where("[i].[Name] LIKE CONCAT('%', @nameContains, '%')")]
        public string NameContains { get; set; }

        [Where("[i].[TypeId]=@typeId")]
        public int? TypeId { get; set; }

        [OrderBy(MyItemsSortOptions.Name, "[i].[Name] ASC")]
        [OrderBy(MyItemsSortOptions.QuantityOnHand, "[i].[QuantityOnHand] DESC")]
        public MyItemsSortOptions OrderBy { get; set; } = MyItemsSortOptions.Name;

        [Offset(30)]
        public int? Page { get; set; }

        protected override IEnumerable<ITestableQuery> GetTestCasesInner()
        {
            yield return new MyItems() { WorkspaceId = 1 };
            yield return new MyItems() { WorkspaceId = 1, IsActive = false };
            yield return new MyItems() { WorkspaceId = 1, IsActive = true };
            yield return new MyItems() { WorkspaceId = 1, OrderBy = MyItemsSortOptions.QuantityOnHand };
            yield return new MyItems() { WorkspaceId = 1, NameContains = "hello" };
            yield return new MyItems() { WorkspaceId = 1, TypeId = 1 };
            yield return new MyItems() { WorkspaceId = 1, Page = 1 };
        }
    }
}
