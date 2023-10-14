using System;
using System.Collections.Generic;

namespace BurkeGroup.Models
{
    public class Tag
    {
        public string? Name { get; set; }
        public string? Color { get; set; }
        public string? ShopmonkeyId { get; set; }
    }

    public class Customer
    {
        public string? ShopmonkeyId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
    }

    public class Vehicle
    {
        public string? ShopmonkeyId { get; set; }
        public string? Make { get; set; }
        public string? Model { get; set; }
        public int? Year { get; set; }
        public string? Type { get; set; }
        public string? Vin { get; set; }
        public string? Submodel { get; set; }
    }

    public class ServiceWriter
    {
        public string? ShopmonkeyId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }

    public class PaymentTerm
    {
        public string? ShopmonkeyId { get; set; }
        public string? Name { get; set; }
    }

    public class APIData
    {
        public int ShopId { get; set; }

        public List<ShopModel> shopList { get; set; }
        public DateTime? AuthorizedDate { get; set; }
        public string? Complaint { get; set; }
        public DateTime? CompletedDate { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? InvoicedDate { get; set; }
        public bool? IsArchived { get; set; }
        public bool? IsAuthorized { get; set; }
        public bool IsInvoice { get; set; }
        public bool IsLaborShopSupplies { get; set; }
        public bool IsLaborTaxable { get; set; }
        public bool IsPaid { get; set; }
        public bool IsPartShopSupplies { get; set; }
        public double JobCardPosition { get; set; }
        public int Number { get; set; }
        public decimal PaidAmount { get; set; }
        public string? PoNumber { get; set; }
        public string? PublicId { get; set; }
        public bool SendCollectPayment { get; set; }
        public bool SendCustomerAuthorize { get; set; }
        public bool SendDisplayActivity { get; set; }
        public bool SendDisplayAuthorizations { get; set; }
        public bool SendDisplayMessages { get; set; }
        public decimal SendRequestedAmount { get; set; }
        public string? ShopmonkeyId { get; set; }
        public string? TechRecommendation { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime UpdateDate { get; set; }
        public string? Name { get; set; }
        public int MileageIn { get; set; }
        public int MileageOut { get; set; }
        public string? Workflow { get; set; }
        public string? WorkflowId { get; set; }
        public Tag[]? Tags { get; set; }
        public Customer? Customer { get; set; }
        public Vehicle? Vehicle { get; set; }
        public ServiceWriter? ServiceWriter { get; set; }
        public PaymentTerm? PaymentTerm { get; set; }
    }
}
