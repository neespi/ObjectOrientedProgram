using System;
using System.Collections.Generic;
using System.Text;
using Bridges.ApplicationServices.Interfaces;

namespace Bridges.ApplicationServices.GetBridgesPointListUseCase
{
    public interface IGetBridgesPointListUseCase 
        : IUseCase<GetBridgesPointListUseCaseRequest, GetBridgesPointListUseCaseResponse>
    {
    }
}
