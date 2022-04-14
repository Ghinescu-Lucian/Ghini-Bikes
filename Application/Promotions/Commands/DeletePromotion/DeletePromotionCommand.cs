using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Promotions.Commands.DeletePromotion
{
    public class DeletePromotionCommand : IRequest<PromoPackage>
    {
        public int Id { get; set; }
    }
}
