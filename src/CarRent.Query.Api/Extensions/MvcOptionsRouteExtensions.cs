namespace CarRent.Query.Api.Extensions;

internal static class MvcOptionsRouteExtensions
{
    public static void UseGlobalRoutePrefix(this MvcOptions opts, IRouteTemplateProvider routeAttribute)
    {
        if (routeAttribute is null)
        {
            throw new ArgumentNullException(nameof(routeAttribute));
        }

        opts.Conventions.Add(new GlobalRouteConvention(routeAttribute));
    }

    public static void UseGlobalRoutePrefix(this MvcOptions opts, string prefix)
    {
        if (string.IsNullOrWhiteSpace(prefix))
        {
            throw new ArgumentException($"{nameof(prefix)} cannot be empty", nameof(prefix));
        }

        opts.UseGlobalRoutePrefix(new RouteAttribute(prefix));
    }
}

internal class GlobalRouteConvention : IApplicationModelConvention
{
    private readonly AttributeRouteModel _routePrefix;

    public GlobalRouteConvention(IRouteTemplateProvider route)
    {
        if (route is null)
        {
            throw new ArgumentNullException(nameof(route));
        }

        _routePrefix = new AttributeRouteModel(route);
    }

    public void Apply(ApplicationModel application)
    {
        foreach (var selector in application.Controllers.SelectMany(c => c.Selectors))
        {
            if (selector.AttributeRouteModel != null)
            {
                selector.AttributeRouteModel = AttributeRouteModel.CombineAttributeRouteModel(_routePrefix, selector.AttributeRouteModel);
            }
            else
            {
                selector.AttributeRouteModel = _routePrefix;
            }
        }
    }
}
