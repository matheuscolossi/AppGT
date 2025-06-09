using System.Configuration;
using System.Data.SqlClient;

namespace ProjetoIntegradorLojaGearTrack
{
    public static class Database
    {
        public static string ConnectionString =>
            ConfigurationManager
                .ConnectionStrings["GearTrackConnection"]
                .ConnectionString;
    }
}
