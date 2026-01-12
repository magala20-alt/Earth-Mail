using System;
using System.Collections.Generic;
using System.Data;
using System.IO.Packaging;
using System.Threading.Tasks;
using Postal_Management_System.Core.Interfaces;
using Postal_Management_System.Core.Entities;
using Postal_Management_System.Core.Data;


namespace Postal_Management_System.Core.Services
{
    public class InvoiceEngine
    {
        
        private readonly IStoreRepository<Tracking> _trackingpackagerepository;


        public InvoiceEngine(IStoreRepository<Tracking> trackingpackagerepository)
        {
            _trackingpackagerepository = trackingpackagerepository ?? throw new ArgumentNullException(nameof(trackingpackagerepository)); ;
        }

       //method to compute bill
        private decimal Compute(decimal weight, decimal size, bool priority)
        {
            decimal baseFee = 40;
            decimal weightFee = weight * 8;
            decimal sizeFee = size * 6;
            decimal fastFee = priority ? 25 : 0;

            return baseFee + weightFee + sizeFee + fastFee;
        }

        // Call after the package has been saved
        public async Task<Tracking> GenerateForAsync(Packages package)
        {
            if (package == null)
                throw new ArgumentNullException(nameof(package));

            decimal size = package.Height * package.Width * package.Length;
            decimal cost = Compute(package.Weight, size, package.Status == "Yes");

            string nextTrackingId = _trackingpackagerepository.GetNextCustomId<Tracking>();
            // Check if nextTrackingId is null or empty (i.e., the first record)
            if (string.IsNullOrEmpty(nextTrackingId))
            {
                nextTrackingId = "T001";
            }
            var tracking = new Tracking
            {
                TrackingID = nextTrackingId,            
                PackageID = package.PackageID,
                declared = "Auto-generated",
                CustomBill = (int)cost,
                PaymentStatus = "Pending",
                BilledOn = DateTime.UtcNow,
                custID="C001",
                EmployeeID="E001"
            };

            await _trackingpackagerepository.AddAsync(tracking);
            

            return tracking;
        }
       
    }
}
