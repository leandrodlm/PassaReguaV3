using System;
using System.Collections.Generic;
using System.Text;

namespace PassaRegua
{
    public class Pessoa
    {
        public string nomePessoa { get; set; }
        public Double valorTotal { get; set; }
        public int ID { get; set; }

        public void addValue(Double v)
        {
            valorTotal += v;
        }
    }

}
