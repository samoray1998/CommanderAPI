using System.Collections.Generic;
using AutoMapper;
using Commander.Data;
using Commander.Dtos;
using Commander.Models;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommandsController : ControllerBase
    {
        private readonly ICommanderRepo _repo;
        private readonly IMapper _mapper;

        public CommandsController(ICommanderRepo repo,IMapper mapper)
        {
            _repo=repo;
            _mapper=mapper;
        }
    //    private readonly MockCommanderRepo _mockcommanderRepo=new MockCommanderRepo();

        [HttpGet]
       public ActionResult <IEnumerable<CommandReadDto>> GetCommands(){
           var cmds=_repo.GetAppCommands();
           return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(cmds));
       }
       [HttpGet("{id}",Name="GetCommandByID")]
       public ActionResult <CommandReadDto> GetCommandByID(int id){
           var cc=_repo.GetCommandById(id);
           if (cc!=null)
           {
           return Ok(_mapper.Map<CommandReadDto>(cc));
               
           }else
           {
               return NotFound();
           }
       }
       [HttpPost]
       public ActionResult <CommandReadDto> CreateNewCommand(CommandCreateDto newCmd){
           var commandModel=_mapper.Map<Command>(newCmd);
           _repo.CreateCommand(commandModel);
           _repo.SavaChanges();
           var commandReadDto=_mapper.Map<CommandReadDto>(commandModel);
           return CreatedAtRoute(nameof(GetCommandByID),new {Id=commandReadDto.Id},commandReadDto);
       }
       [HttpPut("{id}")]
       public ActionResult UpdateCommand(int Id,CommandUpDateDto commandUpDateDto){
           var commandModelForm=_repo.GetCommandById(Id);
           if (commandUpDateDto==null)
           {
               return NotFound();
           }
           _mapper.Map(commandUpDateDto,commandModelForm);
           _repo.UpDateCommand(commandModelForm);
           _repo.SavaChanges();
           return NoContent();
       }
    }
}