using AutoMapper;
using CoreCodeCamp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreCodeCamp.Data
{
    public class CampProfile : Profile
    {
        public CampProfile()
        {
            this.CreateMap<Camp, CampModel>()
                .ForMember(c => c.Venue, o => o.MapFrom(m => m.Location.VenueName))
                .ReverseMap() ;

            this.CreateMap<Talk, TalkModel>()
                .ReverseMap()
                .ForMember(t => t.Camp, opt => opt.Ignore())
                .ForMember(t => t.Speaker, opt => opt.Ignore()); 
            // ignore mapping from talkModel to talk
            // we do want mapping from talk to talkModel, so this is done after ReverseMap

            this.CreateMap<Speaker, SpeakerModel>()
                .ReverseMap();
            //this.CreateMap<CampModel, Camp>()
            //    .ForPath(c => c.Location.VenueName, m => m.MapFrom(o => o.Venue));
        }
    }
}
