using System;

class PontoApp{

	private static bool Foo(String msg){
		if(msg.Length == 1){
			return true;
		}
		else if(msg[0] != msg[msg.Length - 1]){
			return false;
		}
		else if(msg.Length == 2){
			return true;
		}
		else{
			return Foo(msg.Substring(1, msg.Length-2));
			
		}
	}
	static void Main()
	{
		Console.WriteLine("result = {0}", Foo("osso"));
	}

}