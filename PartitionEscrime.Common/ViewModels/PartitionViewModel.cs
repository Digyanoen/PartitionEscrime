using PartitionEscrime.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PartitionEscrime.Common.ViewModels
{
    public class PartitionViewModel
    {
        public List<Passe> Partition;

        public PartitionViewModel()
        {
            Partition = new List<Passe>
            {
                new Passe{ActionA="TestA", ActionB="TestB" },
                new Passe{ActionA="TestA", ActionB="TestB" },
                new Passe{ActionA="TestA", ActionB="TestB" },
                new Passe{ActionA="urhdte'jrj", ActionB="TestB" }
            };
        }
    }
}
