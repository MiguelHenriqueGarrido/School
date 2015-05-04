using System;
using System.Reflection;

class Program {
static void Main() {
 }
static void invokeAll(String path){
        Type objType = Assembly.LoadFrom(path).GetType();
		if(objType != null){
        MethodInfo[] methods = objType.GetMethods(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
			foreach (MethodInfo m in methods){
			m.Invoke(Activator.CreateInstance(objType), m.GetParameters());
			}
    }
	}
}
 