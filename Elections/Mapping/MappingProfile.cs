using AutoMapper;
using Elections.Controllers.Resorces;
using Elections.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elections.Mapping
{
    public class MappingProfile: Profile
    {
       
        public MappingProfile()
        {

            CreateMap<UserResorce, User>()
                .ForMember(u => u.Id, us => us.Ignore());

            CreateMap<ElectionResorce, Election>()
                .ForMember(e => e.Id, es => es.Ignore());

            CreateMap<OptionToVoteResorce, OptionToVote>()
                .ForMember(o => o.Id, os => os.Ignore());

            CreateMap<AreaResorce, Area>()
                .ForMember(a => a.Id, os => os.Ignore());

            CreateMap<FaultResorce, Fault>()
               .ForMember(a => a.Id, os => os.Ignore());
            
           

            CreateMap<ReplyResorce, Reply>()
               .ForMember(a => a.Id, os => os.Ignore());

            CreateMap<VoterResorce, Voter>()
               .ForMember(a => a.Id, os => os.Ignore());
            
            CreateMap<VoterResorceWithoutElection, Voter>()
               .ForMember(a => a.Id, os => os.Ignore());





            CreateMap<User, UserResorce>();

            CreateMap<Election, ElectionResorce>()
                .ForMember(e => e.IsOpen, er => er.Ignore());

            CreateMap<OptionToVote, OptionToVoteResorce>();

            CreateMap<Area, AreaResorce>();

            CreateMap<Fault, FaultResorce>();


            CreateMap<Reply, ReplyResorce>();

            CreateMap<Voter, VoterResorce>();
            CreateMap<Voter, VoterResorceWithoutElection>();
        }

        
    }
}
