﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBDiff.Schema.SQLServer.Generates.Model;

namespace DBDiff.Schema.SQLServer.Generates.Generates.SQLCommands
{
    internal static class FunctionSQLCommand
    {
        public static string Get(DatabaseInfo.VersionTypeEnum version)
        {
            if (version == DatabaseInfo.VersionTypeEnum.SQLServer2005) return Get2005();
            if (version == DatabaseInfo.VersionTypeEnum.SQLServer2008) return Get2008();
            return "";
        }

        private static string Get2005()
        {
            string sql = "";
            sql += "select distinct ";
            sql += "T.name AS ReturnType, PP.max_length, PP.precision, PP.Scale, ";
            sql += "ISNULL(CONVERT(varchar,AM.execute_as_principal_id),'CALLER') as ExecuteAs, ";
            sql += "P.type, ";
            sql += "AF.name AS assembly_name, ";
            sql += "AM.assembly_class, ";
            sql += "AM.assembly_id, ";
            sql += "AM.assembly_method, ";
            sql += "ISNULL('[' + S3.Name + '].[' + object_name(D2.object_id) + ']','') AS DependOut, '[' + S2.Name + '].[' + object_name(D.referenced_major_id) + ']' AS TableName, D.referenced_major_id, OBJECTPROPERTY (P.object_id,'IsSchemaBound') AS IsSchemaBound, P.object_id, S.name as owner, P.name as name from sys.objects P ";
            sql += "INNER JOIN sys.schemas S ON S.schema_id = P.schema_id ";
            sql += "LEFT JOIN sys.sql_dependencies D ON P.object_id = D.object_id ";
            sql += "LEFT JOIN sys.objects O ON O.object_id = D.referenced_major_id ";
            sql += "LEFT JOIN sys.schemas S2 ON S2.schema_id = O.schema_id ";
            sql += "LEFT JOIN sys.sql_dependencies D2 ON P.object_id = D2.referenced_major_id ";
            sql += "LEFT JOIN sys.objects O2 ON O2.object_id = D2.object_id ";
            sql += "LEFT JOIN sys.schemas S3 ON S3.schema_id = O2.schema_id ";
            sql += "LEFT JOIN sys.assembly_modules AM ON AM.object_id = P.object_id  ";
            sql += "LEFT JOIN sys.assemblies AF ON AF.assembly_id = AM.assembly_id ";
            sql += "LEFT JOIN sys.parameters PP ON PP.object_id = AM.object_id AND PP.parameter_id = 0 and PP.is_output = 1 ";
            sql += "LEFT JOIN sys.types T ON T.system_type_id = PP.system_type_id ";
            sql += "WHERE P.type IN ('IF','FN','TF','FS') ORDER BY P.object_id";
            return sql;
        }

        private static string Get2008()
        {
            string sql = "";
            sql += "select distinct ";
            sql += "T.name AS ReturnType, PP.max_length, PP.precision, PP.Scale, ";
            sql += "ISNULL(CONVERT(varchar,AM.execute_as_principal_id),'CALLER') as ExecuteAs, ";
            sql += "P.type, ";
            sql += "AF.name AS assembly_name, ";
            sql += "AM.assembly_class, ";
            sql += "AM.assembly_id, ";
            sql += "AM.assembly_method, ";
            sql += "ISNULL('[' + S3.Name + '].[' + object_name(D2.object_id) + ']','') AS DependOut, '[' + S2.Name + '].[' + object_name(D.referenced_major_id) + ']' AS TableName, D.referenced_major_id, OBJECTPROPERTY (P.object_id,'IsSchemaBound') AS IsSchemaBound, P.object_id, S.name as owner, P.name as name from sys.objects P ";
            sql += "INNER JOIN sys.schemas S ON S.schema_id = P.schema_id ";
            sql += "LEFT JOIN sys.sql_dependencies D ON P.object_id = D.object_id ";
            sql += "LEFT JOIN sys.objects O ON O.object_id = D.referenced_major_id ";
            sql += "LEFT JOIN sys.schemas S2 ON S2.schema_id = O.schema_id ";
            sql += "LEFT JOIN sys.sql_dependencies D2 ON P.object_id = D2.referenced_major_id ";
            sql += "LEFT JOIN sys.objects O2 ON O2.object_id = D2.object_id ";
            sql += "LEFT JOIN sys.schemas S3 ON S3.schema_id = O2.schema_id ";
            sql += "LEFT JOIN sys.assembly_modules AM ON AM.object_id = P.object_id  ";
            sql += "LEFT JOIN sys.assemblies AF ON AF.assembly_id = AM.assembly_id ";
            sql += "LEFT JOIN sys.parameters PP ON PP.object_id = AM.object_id AND PP.parameter_id = 0 and PP.is_output = 1 ";
            sql += "LEFT JOIN sys.types T ON T.system_type_id = PP.system_type_id ";
            sql += "WHERE P.type IN ('IF','FN','TF','FS') ORDER BY P.object_id";
            return sql;
        }
    }
}
