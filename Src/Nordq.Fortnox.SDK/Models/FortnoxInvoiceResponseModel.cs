using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

namespace Nordq.Fortnox.SDK.Models
{
    public class FortnoxInvoiceResponseModel
    {
        public FortnoxResponseMetaData MetaInformation { get; set; }
        public List<Invoice> Invoices { get; set; }
    }

    public class Invoice
    {
        public string Project { get; set; }
        public string PrintTemplate { get; set; }
        public string PriceList { get; set; }
        public string Phone2 { get; set; }
        public string Phone1 { get; set; }
        public string PaymentWay { get; set; }
        public string OurReference { get; set; }
        [ReadOnly(true)]
        public string OrganisationNumber { get; set; }
        [ReadOnly(true)]
        public string OrderReference { get; set; }
        [ReadOnly(true)]
        public string OfferReference { get; set; }
        public string OCR { get; set; }
        public string NotCompleted { get; set; }
        [ReadOnly(true)]
        public string Net { get; set; }
        [ReadOnly(true)]
        public string LastRemindDate { get; set; }
        public string Language { get; set; }
        public string Remarks { get; set; }
        public List<InvoiceRow> InvoiceRows { get; set; }
        [ReadOnly(true)]
        public string Reminders { get; set; }
        [ReadOnly(true)]
        public string Sent { get; set; }
        [ReadOnly(true)]
        [XmlAttribute]
        public string url { get; set; }
        public string ZipCode { get; set; }
        public string YourReference { get; set; }
        public string YourOrderNumber { get; set; }
        public string WayOfDelivery { get; set; }
        [ReadOnly(true)]
        public string VoucherYear { get; set; }
        [ReadOnly(true)]
        public string VoucherSeries { get; set; }
        [ReadOnly(true)]
        public string VoucherNumber { get; set; }
        public string VATIncluded { get; set; }
        public string ExternalInvoiceReference2 { get; set; }
        public string ExternalInvoiceReference1 { get; set; }
        [ReadOnly(true)]
        public string TotalVAT { get; set; }
        [ReadOnly(true)]
        public string TotalToPay { get; set; }
        [ReadOnly(true)]
        public string Total { get; set; }
        public string TermsOfPayment { get; set; }
        public string TermsOfDelivery { get; set; }
        [ReadOnly(true)]
        public string TaxReduction { get; set; }
        [ReadOnly(true)]
        public string RoundOff { get; set; }
        [ReadOnly(true)]
        public string InvoiceReference { get; set; }
        [ReadOnly(true)]
        public string InvoicePeriodEnd { get; set; }
        [ReadOnly(true)]
        public string InvoicePeriodStart { get; set; }
        [ReadOnly(true)]
        public string CreditInvoiceReference { get; set; }
        [ReadOnly(true)]
        public string Credit { get; set; }
        public string CostCenter { get; set; }
        public string Country { get; set; }
        [ReadOnly(true)]
        public string ContributionValue { get; set; }
        [ReadOnly(true)]
        public string ContributionPercent { get; set; }
        public string ContractReference { get; set; }
        public string Comments { get; set; }
        public string City { get; set; }
        [ReadOnly(true)]
        public string Cancelled { get; set; }
        [ReadOnly(true)]
        public string Booked { get; set; }
        [ReadOnly(true)]
        public string BasisTaxReduction { get; set; }
        [ReadOnly(true)]
        public string Balance { get; set; }
        public string Address2 { get; set; }
        public string Address1 { get; set; }
        public string AdministrationFeeVAT { get; set; }
        public string AdministrationFee { get; set; }
        public string Currency { get; set; }
        public string CurrencyRate { get; set; }
        public string CurrencyUnit { get; set; }
        public string CustomerName { get; set; }
        public string InvoiceDate { get; set; }
        [ReadOnly(true)]
        public string HouseWork { get; set; }
        [ReadOnly(true)]
        public string Gross { get; set; }
        [ReadOnly(true)]
        public string FreightVAT { get; set; }
        public string Freight { get; set; }
        public string EUQuarterlyReport { get; set; }
        [ReadOnly(true)]
        [XmlAttribute]
        public string urlTaxReductionList { get; set; }
        public string DueDate { get; set; }
        public string DeliveryZipCode { get; set; }
        public string DeliveryName { get; set; }
        public string DeliveryDate { get; set; }
        public string DeliveryCountry { get; set; }
        public string DeliveryCity { get; set; }
        public string DeliveryAddress2 { get; set; }
        public string DeliveryAddress1 { get; set; }
        public string CustomerNumber { get; set; }
        public string DocumentNumber { get; set; }
        [ReadOnly(true)]
        public string NoxFinans { get; set; }
    }

    public class InvoiceRow
    {
        [ReadOnly(true)]
        public string TotalExcludingVAT { get; set; }
        [ReadOnly(true)]
        public string Total { get; set; }
        public string Project { get; set; }
        [ReadOnly(true)]
        public string PriceExcludingVAT { get; set; }
        public string Price { get; set; }
        public string HouseWorkType { get; set; }
        public string HouseWorkHoursToReport { get; set; }
        public string HouseWork { get; set; }
        public string Discount { get; set; }
        public string Description { get; set; }
        public string DeliveredQuantity { get; set; }
        public string CostCenter { get; set; }
        [ReadOnly(true)]
        public string ContributionValue { get; set; }
        [ReadOnly(true)]
        public string ContributionPercent { get; set; }
        public string ArticleNumber { get; set; }
        public string AccountNumber { get; set; }
        public string Unit { get; set; }
        public string VAT { get; set; }
    }
}