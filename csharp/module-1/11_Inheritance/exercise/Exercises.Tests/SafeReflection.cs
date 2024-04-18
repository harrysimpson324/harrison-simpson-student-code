using System;
using System.Linq;
using System.Reflection;

public class SafeReflection
{
    public static Type GetType(string className, string @namespace = "")
    {
        Type retType = null;
        try
        {
            retType = Type.GetType(className);

            if (retType == null)
            {
                if (@namespace.Contains("."))
                {
                    retType = Type.GetType($"{@namespace}.{className}, {@namespace.Substring(0, @namespace.IndexOf("."))}");
                }
                else
                {
                    retType = Type.GetType($"{@namespace}.{className}, {@namespace}");
                }
            }

            if (retType == null)
            {
                string thisNamespace = Assembly.GetExecutingAssembly().EntryPoint.DeclaringType.Namespace;
                retType = Type.GetType($"{thisNamespace}.{className}, {thisNamespace}");
            }
        }
        catch (Exception) { }

        return retType;
    }

    public static object CreateInstance(Type type, object[] parameters)
    {
        if (type == null) return null;
        try
        {
            return Activator.CreateInstance(type, parameters);
        }
        catch (Exception)
        {
            return null;
        }
    }

    public static bool HasConstructor(Type type, Type[] parameters)
    {
        if (type == null) return false;
        try
        {
            ConstructorInfo constructorInfo = type.GetConstructor(parameters);
            return constructorInfo != null;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public static ConstructorInfo GetConstructor(Type type, Type[] parameters)
    {
        if (type == null) return null;
        try
        {
            ConstructorInfo constructorInfo = type.GetConstructor(parameters);

            if (constructorInfo == null) return null;

            // ensure parameter types are exact, GetConstructor() can return constructors with base class (object) instead specific type (string) we want
            for (int i = 0; i < constructorInfo.GetParameters().Length; i++)
            {
                if (parameters[i] != constructorInfo.GetParameters()[i].ParameterType)
                {
                    return null;
                }
            }
            return constructorInfo;
        }
        catch (Exception)
        {
            return null;
        }
    }

    public static MethodInfo GetMethod(Type type, string methodName)
    {
        if (type == null) return null;
        try
        {
            MethodInfo method = type.GetMethod(methodName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            return method;
        }
        catch (Exception)
        {
            return null;
        }
    }

    public static object InvokeMethod(object instance, string methodName, object[] parameters)
    {
        if (instance == null) return null;
        try
        {
            MethodInfo method = instance.GetType().GetMethod(methodName);
            return method.Invoke(instance, parameters);
        }
        catch (Exception)
        {
            return null;
        }
    }

    public static bool HasProperty(Type type, string propName)
    {
        if (type == null) return false;
        foreach (PropertyInfo prop in GetProperties(type))
        {
            if (prop.Name == propName)
            {
                return true;
            }
        }
        return false;
    }

    public static PropertyInfo GetProperty(Type type, string propName)
    {
        if (type == null) return null;
        foreach (PropertyInfo prop in GetProperties(type))
        {
            if (prop.Name == propName)
            {
                return prop;
            }
        }
        return null;
    }

    public static object GetPropertyValue(object instance, string propName)
    {
        if (instance == null) return null;
        foreach (PropertyInfo prop in GetProperties(instance.GetType()))
        {
            if (prop.Name == propName)
            {
                return prop.GetValue(instance);
            }
        }
        return null;
    }

    public static void SetPropertyValue(object instance, string propName, object propValue)
    {
        if (instance == null) return;
        foreach (PropertyInfo prop in GetProperties(instance.GetType()))
        {
            if (prop.Name == propName && prop.CanWrite)
            {
                try
                {
                    prop.SetValue(instance, propValue);
                }
                catch (Exception) { }
            }
        }
    }

    public static FieldInfo GetField(Type type, string fieldName)
    {
        if (type == null) return null;
        foreach (FieldInfo field in GetFields(type))
        {
            if (field.Name == fieldName)
            {
                return field;
            }
        }
        return null;
    }

    public static object GetFieldValue(object instance, string fieldName)
    {
        if (instance == null) return null;
        foreach (FieldInfo field in GetFields(instance.GetType()))
        {
            if (field.Name == fieldName)
            {
                return field.GetValue(instance);
            }
        }
        return null;
    }

    public static void SetFieldValue(object instance, string fieldName, object fieldValue)
    {
        if (instance == null) return;
        foreach (FieldInfo field in GetFields(instance.GetType()))
        {
            if (field.Name == fieldName)
            {
                field.SetValue(instance, fieldValue);
            }
        }
    }

    private static PropertyInfo[] GetProperties(Type type)
    {
        return type.GetProperties();
    }

    private static FieldInfo[] GetFields(Type type)
    {
        return type.GetRuntimeFields().ToArray();
    }
}
