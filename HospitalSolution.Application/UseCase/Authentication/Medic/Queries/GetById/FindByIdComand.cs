

using MediatR;

namespace findByIdComand;

public record FindByIdComand
(
    string Id
): IRequest<AuthenticationMedicResult>;