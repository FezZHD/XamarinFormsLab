using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XFLab.Model.Types;

namespace XFLab.Model
{
    internal sealed class JobsSingletone
    {

        private static readonly Lazy<JobsSingletone> lazy = new Lazy<JobsSingletone>(() => new JobsSingletone());

        internal static JobsSingletone Instance { get { return lazy.Value; } }

        internal List<Job> JobsList { get; private set; }

        private JobsSingletone()
        {
            
        }


        internal void CreateList(List<Job> newList)
        {
            JobsList = new List<Job>(newList);
        }


        internal void Add(Job job)
        {
            JobsList.Add(job);
        }
    }
}
