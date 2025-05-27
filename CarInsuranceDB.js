// Set the database
use("CarInsuranceDB");

// Create collections
db.createCollection("Claims");
db.createCollection("Policies");

// Insert sample document into Policies
db.Policies.insertOne({
  Id: 1,
  PolicyNumber: "POL123456",
  CarPlateNumber: "ABC123",
  EffectiveDate: new Date("2024-01-01"),
  ExpirationDate: new Date("2025-01-01"),
  Premium: 499.99,
  Status: "Active",
  Insured: {
    Id: 1,
    FirstName: "Jane",
    LastName: "Doe",
    Email: "jane.doe@example.com",
    PhoneNumber: "+1234567890",
  },
});

// Insert sample document into Claims
db.Claims.insertOne({
  PolicyId: "POL123456",
  ClaimDate: new Date(),
  Description: "Accident on highway",
  Amount: 1800.75,
  Status: "Open",
  Insured: {
    Id: 1,
    FirstName: "Jane",
    LastName: "Doe",
    Email: "jane.doe@example.com",
    PhoneNumber: "+1234567890",
  },
  Notes: [
    {
      Id: 1,
      CreatedBy: "Agent John",
      CreatedAt: new Date(),
      Note: "Initial claim created",
    },
  ],
});
