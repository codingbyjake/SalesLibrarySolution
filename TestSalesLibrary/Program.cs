
using SalesLibrary;

//var custCtrl = new CustomersController("localhost", "sqlexpress"); //another valid way
//CustomersController custCtrl = new ("localhost", "sqlexpress"); //newest valid way
CustomersController custCtrl = new CustomersController("localhost", "sqlexpress");

var customers = custCtrl.GetBySalesRange(20000, 50000);

foreach(var cust in customers) {
    Console.WriteLine($"{cust.Id} | {cust.Name} | {cust.City} | {cust.State} | {cust.Sales} | {cust.Active}");
}


//var max = custCtrl.GetById(36);

//if(max is null) {
//    Console.WriteLine("Not found");
//    return;
//}

//max.Name = "MAX Technical Training v2";

//var success = custCtrl.Update(max);

//if (!success) {
//    Console.WriteLine("Update failed!");
//    return;
//}

//var newCustomer = new Customer {
//    Id = 0, Name = "MAX3", City = "Mason", State = "OH", Sales = 1000, Active = true
//};

//var success = custCtrl.Add(newCustomer);
//if (!success) {
//    Console.WriteLine("Add Failed!");
//}


//***********************View All Customers Names*****************
//var customers = custCtrl.GetAll();

//foreach (var customer in customers) {
//    Console.WriteLine(customer.Name);
//}
//^^^^^^^^^^^^^^^^^^^^^^View All Customers Names^^^^^^^^^^^^^^^^^^^

//var success = custCtrl.Delete(38);


////***********************View Customer By Id*****************
//var cust = custCtrl.GetById(38);

//if (cust is null) {
//    Console.WriteLine("Not found!");
//}
//else {
//    Console.WriteLine($"{cust.Id} | {cust.Name} | {cust.City} | {cust.State} | {cust.Sales} | {cust.Active}");
//}
//^^^^^^^^^^^^^^^^^^^^^^View Customer By Id^^^^^^^^^^^^^^^^^^^

custCtrl.CloseConnection();