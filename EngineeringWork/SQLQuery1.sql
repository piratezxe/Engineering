select DailyRoutes.DriverId, DailyRoutes.Id, PassengerBooking.DailyRouteId 
from DailyRoutes
Inner join PassengerBooking ON DailyRoutes.Id = PassengerBooking.DailyRouteId;