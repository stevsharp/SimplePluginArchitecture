using Microsoft.AspNetCore.Mvc.ApplicationModels;

using Shared;

public class ModuleRoutingConvention : IActionModelConvention
{
    private readonly IEnumerable<Plugin> _modules;

    public ModuleRoutingConvention(IEnumerable<Plugin> modules)
    {
        _modules = modules;
    }

    public void Apply(ActionModel action)
    {
        var module = _modules.FirstOrDefault(m => m.Assembly == action.Controller.ControllerType.Assembly);

        if (module is null)
            return;


        action.RouteValues.Add("module", module.RoutePrefix);
    }
}



