using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleAssist.Application.Repositories;

namespace VehicleAssist.Application.Customer.Queries
{
    public record GetCalendarDataFromCustomer : IRequest<CalendarFromCustomerQueryResult>
    {
        public int CustomerId { get; set; }
    }

    public class GetCalendarDataFromCustomerQueryHandler : IRequestHandler<GetCalendarDataFromCustomer, CalendarFromCustomerQueryResult>
    {

        ICustomerRepository _customerRepository;

        public GetCalendarDataFromCustomerQueryHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<CalendarFromCustomerQueryResult> Handle(GetCalendarDataFromCustomer request, CancellationToken cancellationToken)
        {
          
            
            CalendarData data = _customerRepository.GetCalenderData(request.CustomerId);

            CalendarFromCustomerQueryResult result = new(data);

            return result;

        }
    }

    public record CalendarFromCustomerQueryResult 
    {
        public CalendarFromCustomerQueryResult(CalendarData data)
        {
            Appointments = new List<AppointmentDTO>();
            Reminders = new List<ReminderDTO>();

            foreach (var appointment in data.Appointments)
            {
                Appointments?.Add(AppointmentDTO.FromAppointment(appointment));
            }
            foreach (var reminder in data.Reminders)
            {
               Reminders?.Add(ReminderDTO.FromReminder(reminder));
            }
        }

        public List<ReminderDTO> Reminders { get; set; }
        public List<AppointmentDTO> Appointments{ get; set; }
    }
}
