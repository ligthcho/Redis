using StackExchange.Redis;
using System;
using System.Threading.Tasks;

namespace RedisForKey
{
    class Program
    {
        static async Task Main(string[] args)
        {
			//创建连接
			var conn = await ConnectionMultiplexer.ConnectAsync("127.0.0.1");
			//获取db
			var db = conn.GetDatabase(0);
			//遍历集群内服务器
			foreach(var endPoint in conn.GetEndPoints())
			{
				//获取指定服务器
				var server = conn.GetServer(endPoint);
				//在指定服务器上使用 keys 或者 scan 命令来遍历key
				foreach(var key in server.Keys(0,"test.*"))
				{
					//获取key对于的值
					var val = db.StringGet(key);
					Console.WriteLine($"key: {key}, value: {val}");
				}
			}
			Console.ReadKey();
		}
    }
}
