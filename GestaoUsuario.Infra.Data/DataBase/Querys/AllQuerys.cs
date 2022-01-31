 
using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace GestaoUsuario.Infra.Data.DataBase.Querys
{
    public static class AllQueries 
    {
		private static string GetQuery([CallerMemberName]string propertyName = null)
        {
            var fileName = $"GestaoUsuario.Infra.Data.DataBase.Querys.{propertyName}.sql";

            var stream = typeof(AllQueries).Assembly.GetManifestResourceStream(fileName);

            if (stream == null) throw new Exception($"The file {propertyName}.sql was not found in GestaoUsuario.Infra.Data.DataBase.Querys");

            using (var sr = new StreamReader(stream))
            {
                return sr.ReadToEnd(); 
            }
        } 

    }
}
