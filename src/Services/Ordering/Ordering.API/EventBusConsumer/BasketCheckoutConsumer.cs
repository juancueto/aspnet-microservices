using AutoMapper;
using EventBus.Messages.Events;
using MassTransit;
using MediatR;
using Ordering.Application.Features.Orders.Commands.CheckoutOrder;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Ordering.API.EventBusConsumer
{
    public class BasketCheckoutConsumer : IConsumer<BasketCheckoutEvent>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger<BasketCheckoutConsumer> _logger;

        public BasketCheckoutConsumer(IMediator mediator, IMapper mapper, ILogger<BasketCheckoutConsumer> logger)
        {
            this._mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this._mapper = mapper ??  throw new ArgumentNullException(nameof(mapper));
            this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task Consume(ConsumeContext<BasketCheckoutEvent> context)
        {
            var command = _mapper.Map<CheckoutOrderCommand>(context.Message);

            var result = await _mediator.Send(command);

            _logger.LogInformation("BasketCheckoutEvent consumed successfully. Create Order Id: {newOrderId}", result);
        }
    }
}
