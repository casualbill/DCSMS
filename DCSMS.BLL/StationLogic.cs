using System;
using System.Collections.Generic;
using System.Data;
using DCSMS.DAL;

namespace DCSMS.BLL
{
    public class StationLogic
    {
        StationDB stationDb = new StationDB();

        //维修站查询（所有）
        public DataTable stationQuery()
        {
            DataSet ds = stationDb.stationQuery();
            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        //客户查询 根据客户Id
        public List<String> stationQueryByStaionId(int id)
        {
            List<String> stationInfoStr = new List<string>();
            DataRow dr = stationDb.stationQueryByStationId(id).Tables[0].Rows[0];
            foreach (Object obj in dr.ItemArray)
            {
                stationInfoStr.Add(obj.ToString());
            }

            return stationInfoStr;
        }
    }
}
