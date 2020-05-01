using LunaPetShop.Domain.Commands;
using LunaPetShop.Domain.Commands.Contracts;
using LunaPetShop.Domain.Commands.Produtcs;
using LunaPetShop.Domain.Handlers.Contracts;

namespace LunaPetShop.Domain.Handlers.Products
{
    public class UpdateProductHandler : IHandler<UpdateProductCommand>
    {
        public UpdateProductHandler()
        {

        }

        public ICommandResult handle(UpdateProductCommand command)
        {
            //fast fail validations
            command.Validate();

            if (command.Invalid)
            {
                return new CommandResult("Command invalid", false, command.Notifications);
            }

            return new CommandResult("Product created", true, command);
        }
    }
}