using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace PluginArch;

public class InternalControllerFeatureProvider : ControllerFeatureProvider
    {
        protected override bool IsController(TypeInfo typeInfo)
        {
            var isCustomController = !typeInfo.IsAbstract
                                     && typeof(ControllerBase).IsAssignableFrom(typeInfo)
                                     && !typeInfo.IsVisible
                && !typeInfo.IsPublic
                && typeInfo.IsNotPublic
                && !typeInfo.IsNested
                && !typeInfo.IsNestedPublic
                && !typeInfo.IsNestedFamily
                && !typeInfo.IsNestedPrivate
                && !typeInfo.IsNestedAssembly
                && !typeInfo.IsNestedFamORAssem
                && !typeInfo.IsNestedFamANDAssem;
            return isCustomController || base.IsController(typeInfo);

        bool IsInternal(TypeInfo t)
        {
            return !t.IsVisible
                            && !t.IsPublic
                            && t.IsNotPublic
                            && !t.IsNested
                            && !t.IsNestedPublic
                            && !t.IsNestedFamily
                            && !t.IsNestedPrivate
                            && !t.IsNestedAssembly
                            && !t.IsNestedFamORAssem
                            && !t.IsNestedFamANDAssem;
        }
    }
    }

