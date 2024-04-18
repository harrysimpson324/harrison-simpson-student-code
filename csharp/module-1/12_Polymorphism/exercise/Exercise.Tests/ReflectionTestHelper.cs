using System;
using System.Collections.Generic;
using System.Reflection;

namespace Exercise.Tests
{
    public static class ReflectionTestHelper
    {
        public enum AccessModifier
        {
            None = 0,
            Private,
            Public
        }

        public static string CheckProperty(Type classType, string propertyName, Type propertyType, AccessModifier getterRequired = AccessModifier.Public, AccessModifier setterRequired = AccessModifier.Public)
        {
            // Assert property exists, is of correct type and access
            PropertyInfo propertyInfo = SafeReflection.GetProperty(classType, propertyName);
            if (propertyInfo == null) { return $"{classType.Name} does not have the required property {propertyName}."; }

            if (propertyInfo.PropertyType != propertyType) { return $"{classType.Name} property {propertyName} must be type {GetTypeName(propertyType)}."; }

            MethodInfo getMethodInfo = propertyInfo.GetMethod;
            if (getterRequired == AccessModifier.None)
            {
                if (getMethodInfo != null) { return $"{classType.Name} property {propertyName} must NOT have a getter."; }
            }
            else // A getter is required
            {
                if (getMethodInfo == null) { return $"{classType.Name} property {propertyName} must have a getter."; }
                // A private getter is required
                if (getterRequired == AccessModifier.Private)
                {
                    if (!getMethodInfo.IsPrivate) { return $"{classType.Name} property {propertyName} getter must be private."; }
                }
                else // A public getter is required
                {
                    if (!getMethodInfo.IsPublic) { return $"{classType.Name} property {propertyName} getter must be public."; }
                }
            }

            MethodInfo setMethodInfo = propertyInfo.SetMethod;
            if (setterRequired == AccessModifier.None)
            {
                if (setMethodInfo != null) { return $"{classType.Name} property {propertyName} must NOT have a setter."; }
            }
            else // A setter is required
            {
                if (setMethodInfo == null) { return $"{classType.Name} property {propertyName} must have a setter."; }
                // A private setter is required
                if (setterRequired == AccessModifier.Private)
                {
                    if (!setMethodInfo.IsPrivate) { return $"{classType.Name} property {propertyName} setter must be private."; }
                }
                else // A public setter is required
                {
                    if (!setMethodInfo.IsPublic) { return $"{classType.Name} property {propertyName} setter must be public."; }
                }
            }

            return "";
        }

        public static string CheckField(Type classType, string fieldName, Type fieldType, AccessModifier accessModifier)
        {
            // Assert field exists, is of correct type and access
            FieldInfo fieldInfo = SafeReflection.GetField(classType, fieldName);
            if (fieldInfo == null) { return $"{classType.Name} does not have the required field {fieldName}."; }

            if (fieldInfo.FieldType != fieldType) { return $"{classType.Name} field {fieldName} must be type {GetTypeName(fieldType)}."; }

            return "";
        }

        public static string CheckMethod(Type classType, string methodName, Type returnType, bool isPublic, bool isVirtual, Type[] parameters)
        {
            MethodInfo methodInfo = SafeReflection.GetMethod(classType, methodName);
            if (methodInfo == null) { return $"{classType.Name} does not have the method {methodName}."; }

            if (methodInfo.ReturnType != returnType) { return $"{classType.Name} method {methodName} must return type {GetTypeName(returnType)}."; }

            if (isPublic && !methodInfo.IsPublic) { return $"{classType.Name} method {methodName} must be public."; }
            if (!isPublic && methodInfo.IsPublic) { return $"{classType.Name} method {methodName} must NOT be public."; }

            if (isVirtual && !methodInfo.IsVirtual) { return $"{classType.Name} method {methodName} must be marked virtual."; }
            if (!isVirtual && methodInfo.IsVirtual) { return $"{classType.Name} method {methodName} must NOT be marked virtual."; }

            ParameterInfo[] parameterInfo = methodInfo.GetParameters();

            if (parameterInfo.Length != parameters.Length) { return $"{classType.Name} method {methodName} must accept exactly {parameters.Length} parameter{(parameters.Length == 1 ? "" : "s")}."; }

            for (int i = 0; i < parameters.Length; i++)
            {
                if (parameterInfo[i].ParameterType != parameters[i]) { return $"{classType.Name} method {methodName} parameter {i} must be of type {GetTypeName(parameters[i])}."; }
            }
            return "";
        }

        private static string AliasOrTypeName(Type t)
        {
            Dictionary<Type, string> typeAliases = new Dictionary<Type, string>()
            {
                { typeof(byte), "byte" },
                { typeof(sbyte), "sbyte" },
                { typeof(short), "short" },
                { typeof(ushort), "ushort" },
                { typeof(int), "int" },
                { typeof(uint), "uint" },
                { typeof(long), "long" },
                { typeof(ulong), "ulong" },
                { typeof(float), "float" },
                { typeof(double), "double" },
                { typeof(decimal), "decimal" },
                { typeof(object), "object" },
                { typeof(bool), "bool" },
                { typeof(char), "char" },
                { typeof(string), "string" },
                { typeof(void), "void" }
            };
            return typeAliases.ContainsKey(t) ? typeAliases[t] : t.Name;
        }

        public static string GetTypeName(Type t)
        {
            if (!t.IsGenericType)
            {
                return AliasOrTypeName(t);
            }

            // Build the Generic representation
            string genericArguments = "";
            foreach (Type argType in t.GetGenericArguments())
            {
                if (genericArguments.Length > 0) genericArguments += ", ";
                genericArguments += GetTypeName(argType);
            }
            return $"{t.Name.Substring(0, t.Name.IndexOf("`"))}<{genericArguments}>";
        }
    }
}
