using Application.Interfaces.Repositories;
using AutoMapper;
using Common;
using Common.Infrastructure;
using Common.Infrastructure.Exceptions;
using Common.Infrastructure.ExistsDatabase;
using Common.Models.RequestModels.Update;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Update
{
    public class UpdateUserCommandValidator { 
    }
}
/*
 UserName is uniqued
updateUserCommand to User
send validation email with rabbitmq
save to database
 */