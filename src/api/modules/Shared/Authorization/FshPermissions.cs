﻿using System.Collections.ObjectModel;

namespace TMC.WebApi.Shared.Authorization;

public static class FshAction
{
    public const string View = nameof(View);
    public const string Search = nameof(Search);
    public const string Create = nameof(Create);
    public const string Update = nameof(Update);
    public const string Delete = nameof(Delete);
    public const string Export = nameof(Export);
    public const string Generate = nameof(Generate);
    public const string Clean = nameof(Clean);
    public const string UpgradeSubscription = nameof(UpgradeSubscription);
}

public static class FshResource
{
    public const string Tenants = nameof(Tenants);
    public const string Dashboard = nameof(Dashboard);
    public const string Hangfire = nameof(Hangfire);
    public const string Users = nameof(Users);
    public const string UserRoles = nameof(UserRoles);
    public const string Roles = nameof(Roles);
    public const string RoleClaims = nameof(RoleClaims);
}

public static class FshPermissions
{
    private static readonly FshPermission[] allPermissions =
   {     
        //tenants
        new("View Tenants", FshAction.View, FshResource.Tenants, IsRoot: true),
        new("Create Tenants", FshAction.Create, FshResource.Tenants, IsRoot: true),
        new("Update Tenants", FshAction.Update, FshResource.Tenants, IsRoot: true),
        new("Upgrade Tenant Subscription", FshAction.UpgradeSubscription, FshResource.Tenants, IsRoot: true),

        //identity
        new("View Users", FshAction.View, FshResource.Users),
        new("Search Users", FshAction.Search, FshResource.Users),
        new("Create Users", FshAction.Create, FshResource.Users),
        new("Update Users", FshAction.Update, FshResource.Users),
        new("Delete Users", FshAction.Delete, FshResource.Users),
        new("Export Users", FshAction.Export, FshResource.Users),
        new("View UserRoles", FshAction.View, FshResource.UserRoles),
        new("Update UserRoles", FshAction.Update, FshResource.UserRoles),
        new("View Roles", FshAction.View, FshResource.Roles),
        new("Create Roles", FshAction.Create, FshResource.Roles),
        new("Update Roles", FshAction.Update, FshResource.Roles),
        new("Delete Roles", FshAction.Delete, FshResource.Roles),
        new("View RoleClaims", FshAction.View, FshResource.RoleClaims),
        new("Update RoleClaims", FshAction.Update, FshResource.RoleClaims),
   };

    public static IReadOnlyList<FshPermission> All { get; } = new ReadOnlyCollection<FshPermission>(allPermissions);
    public static IReadOnlyList<FshPermission> Root { get; } = new ReadOnlyCollection<FshPermission>(allPermissions.Where(p => p.IsRoot).ToArray());
    public static IReadOnlyList<FshPermission> Admin { get; } = new ReadOnlyCollection<FshPermission>(allPermissions.Where(p => !p.IsRoot).ToArray());
    public static IReadOnlyList<FshPermission> Basic { get; } = new ReadOnlyCollection<FshPermission>(allPermissions.Where(p => p.IsBasic).ToArray());
}

public record FshPermission(string Description, string Action, string Resource, bool IsBasic = false, bool IsRoot = false)
{
    public string Name => NameFor(Action, Resource);
    public static string NameFor(string action, string resource)
    {
        return $"Permissions.{resource}.{action}";
    }
}


