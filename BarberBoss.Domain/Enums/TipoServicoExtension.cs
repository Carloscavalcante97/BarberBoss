using BarberBoss.Communication.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberBoss.Domain.Enums
{
    public static class TipoServicoExtension
    {
        public static string TipoServicoToString(this ServicesType service)
        {
            return service switch
            {
               ServicesType.Corte => "Corte",
               ServicesType.Barba => "Barba",
                ServicesType.CorteEBarba => "Corte e barba",
                ServicesType.Hidratacao => "Hidratação",
                ServicesType.Lavagem => "Lavagem",
                _ => string.Empty
            };
        }
    }
}
