using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talks.Model.Base;

namespace Talks.Model.Dto
{
    public class TalksDto:BaseDto
    {
        public string Id { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 演讲者
        /// </summary>
        public string Speaker { get; set; }
        /// <summary>
        /// 演讲时间
        /// </summary>
        public DateTime ShowTime { get; set; }
        /// <summary>
        /// 演讲地址
        /// </summary>
        public string ShowAddress { get; set; }
        /// <summary>
        /// 视频代码
        /// </summary>
        public string VideoCode { get; set; }
        /// <summary>
        /// 分类
        /// </summary>
        public string Category { get; set; }
        /// <summary>
        /// 年代
        /// </summary>
        public string Year { get; set; }
        /// <summary>
        /// 是否是连续剧
        /// </summary>
        public bool IsSeries { get; set; }
        /// <summary>
        /// 季：第一季
        /// </summary>
        public string Season { get; set; }
        /// <summary>
        /// 集：第一集，第十集（大结局）
        /// </summary>
        public string Series { get; set; }


        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime AddTime { get; set; }
        /// <summary>
        /// 添加后台用户
        /// </summary>
        public string AddUser { get; set; }
        /// <summary>
        /// 1:正常，0:删除
        /// </summary>
        public string DeleteFlag { get; set; }

        public override void Bind(System.Data.DataRow dr)
        {
            throw new NotImplementedException();
        }
    }
}
