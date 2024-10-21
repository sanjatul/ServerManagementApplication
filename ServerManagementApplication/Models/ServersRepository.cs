namespace ServerManagementApplication.Models
{
    public static class ServersRepository
    {
        private static List<ServerDescription> servers = new List<ServerDescription>()
        {
            new ServerDescription{ServerId=1, Name="Server 01",City="Toronto"},
            new ServerDescription{ServerId=2, Name="Server 02",City="Toronto"},
            new ServerDescription{ServerId=3, Name="Server 03",City="Toronto"},
            new ServerDescription{ServerId=4, Name="Server 04",City="Toronto"},
            new ServerDescription{ServerId=5, Name="Server 05",City="Montral"},
            new ServerDescription{ServerId=6, Name="Server 06",City="Montral"},
            new ServerDescription{ServerId=7, Name="Server 07",City="Montral"},
            new ServerDescription{ServerId=8, Name="Server 08",City="Ottawa"},
            new ServerDescription{ServerId=9, Name="Server 09",City="Ottawa"},
            new ServerDescription{ServerId=10,Name="Server 10",City="Calgary"},
            new ServerDescription{ServerId=11,Name="Server 11",City="Calgary"},
            new ServerDescription{ServerId=12,Name="Server 12",City="Halifax"},
            new ServerDescription{ServerId=13,Name="Server 13",City="Halifax"},
            new ServerDescription{ServerId=14,Name="Server 14",City="Halifax"},
            new ServerDescription{ServerId=15,Name="Server 15",City="Halifax"},
        };
        public static void AddServer(ServerDescription server)
        {
            var maxId = servers.Max(x => x.ServerId);
            server.ServerId = maxId+1;
            servers.Add(server);
        }
        public static List<ServerDescription> GetServers() => servers;

        public static ServerDescription? GetServerByID(int id)
        {
            var server = servers.FirstOrDefault(x => x.ServerId == id);
            if (server != null)
            {
                return new ServerDescription
                {
                    ServerId = server.ServerId,
                    Name = server.Name,
                    City = server.City,
                    IsOnline = server.IsOnline,
                };
            }
            return null;
        }
        public static void UpdateServer(int serverId, ServerDescription server)
        {
            if (serverId != server.ServerId) return;
            var serverToUpdate = servers.FirstOrDefault(x => x.ServerId == serverId);
            if (serverToUpdate != null)
            {

                serverToUpdate.ServerId = server.ServerId;
                serverToUpdate.Name = server.Name;
                serverToUpdate.City = server.City;
                serverToUpdate.IsOnline = server.IsOnline;

            }

        }

        public static void DeleteServer(int serverId)
        {

            var server = servers.FirstOrDefault(x => x.ServerId == serverId);
            if (server != null)
            {
                servers.Remove(server);
            }

        }
        public static List<ServerDescription> SearchServers(string serverFilter)
        {
            return servers.Where(s => s.Name.Contains(serverFilter, StringComparison.OrdinalIgnoreCase)).ToList();
        }
        public static List<ServerDescription> GetServersByCity(string serverFilter)
        {
            return servers.Where(s => s.City.Contains(serverFilter, StringComparison.OrdinalIgnoreCase)).ToList();
        }

    }
}
