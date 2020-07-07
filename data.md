Allergies

```
{
  "resourceType": "AllergyIntolerance",
  "id": "I2-5YGRHZGYRZG3LCYV7TT55FAAX4000000",
  "recordedDate": "1994-10-13T20:04:03Z",
  "patient": {
    "reference": "https://sandbox-api.va.gov/services/fhir/v0/dstu2/Patient/36000036",
    "display": "Mr. Ned189 Renner328"
  },
  "substance": {
    "text": "Latex allergy"
  },
  "status": "active",
  "type": "allergy",
  "note": {
    "time": "1994-10-13T20:04:03Z",
    "text": "Latex allergy"
  },
  "reaction": [
    {
      "certainty": "likely",
      "manifestation": [
        {
          "coding": [
            {
              "system": "urn:oid:2.16.840.1.113883.6.233",
              "code": "36000001",
              "display": "Sneezing and Coughing"
            }
          ]
        }
      ]
    }
  ]
}
```

Conditions

```
{
  "id": "I2-QE577V6FSASU5GG2JFWNIFZ6VY000000",
  "resourceType": "Condition",
  "patient": {
    "reference": "https://sandbox-api.va.gov/services/fhir/v0/dstu2/Patient/36000036",
    "display": "Mr. Ned189 Renner328"
  },
  "dateRecorded": "2016-05-08",
  "code": {
    "coding": [
      {
        "system": "http://snomed.info/sct",
        "code": "10509002",
        "display": "Acute bronchitis (disorder)"
      }
    ],
    "text": "Acute bronchitis (disorder)"
  },
  "category": {
    "coding": [
      {
        "system": "http://argonaut.hl7.org",
        "code": "problem",
        "display": "Problem"
      }
    ],
    "text": "Problem"
  },
  "clinicalStatus": "resolved",
  "verificationStatus": "unknown",
  "onsetDateTime": "2016-05-08T20:04:03Z",
  "abatementDateTime": "2016-05-15T20:04:03Z"
}
```

Diagnostics

```
{
  "id": "I2-FQ4R5X5S2LPHW6VFNETKT4KLM4000000",
  "resourceType": "DiagnosticReport",
  "status": "final",
  "category": {
    "coding": [
      {
        "system": "http://hl7.org/fhir/ValueSet/diagnostic-service-sections",
        "code": "LAB",
        "display": "Laboratory"
      }
    ]
  },
  "code": {
    "text": "panel"
  },
  "subject": {
    "reference": "https://sandbox-api.va.gov/services/fhir/v0/dstu2/Patient/36000036",
    "display": "Mr. Ned189 Renner328"
  },
  "effectiveDateTime": "2016-01-18T21:04:03Z",
  "issued": "2016-01-18T21:04:03Z",
  "_performer": {
    "extension": [
      {
        "url": "http://hl7.org/fhir/StructureDefinition/data-absent-reason",
        "valueCode": "unknown"
      }
    ]
  },
  "result": [
    {
      "reference": "https://sandbox-api.va.gov/services/fhir/v0/dstu2/Observation/I2-I75ZWCZXBVZFDOBY3CEJNE5A7Y000000",
      "display": "Leukocytes [#/volume] in Blood by Automated count"
    },
    {
      "reference": "https://sandbox-api.va.gov/services/fhir/v0/dstu2/Observation/I2-ICILEGNOWI2HIKIRI55K4DTTPI000000",
      "display": "Erythrocytes [#/volume] in Blood by Automated coun"
    },
    {
      "reference": "https://sandbox-api.va.gov/services/fhir/v0/dstu2/Observation/I2-E2SEYPDP5ZCD3J2LSXUFWDAQBQ000000",
      "display": "Hemoglobin [Mass/volume] in Blood"
    },
    {
      "reference": "https://sandbox-api.va.gov/services/fhir/v0/dstu2/Observation/I2-BXLVIDIBMX5XG7QFLFIFWR5UYU000000",
      "display": "Hematocrit [Volume Fraction] of Blood by Automated"
    },
    {
      "reference": "https://sandbox-api.va.gov/services/fhir/v0/dstu2/Observation/I2-YFQEZV3CZ2JK7RPXYRTXLNW3IM000000",
      "display": "MCV [Entitic volume] by Automated count"
    },
    {
      "reference": "https://sandbox-api.va.gov/services/fhir/v0/dstu2/Observation/I2-YQXKJN4IUWAN27VRXK7C423ILE000000",
      "display": "MCH [Entitic mass] by Automated count"
    },
    {
      "reference": "https://sandbox-api.va.gov/services/fhir/v0/dstu2/Observation/I2-HQCIAPOJFTXD6GLSRF3K4QEFWQ000000",
      "display": "MCHC [Mass/volume] by Automated count"
    },
    {
      "reference": "https://sandbox-api.va.gov/services/fhir/v0/dstu2/Observation/I2-MOEIS3AMFAIERWDEA2KP7ZJCDI000000",
      "display": "Erythrocyte distribution width [Entitic volume] by"
    },
    {
      "reference": "https://sandbox-api.va.gov/services/fhir/v0/dstu2/Observation/I2-XUFG373ITJRUHW5N66VB7SAREU000000",
      "display": "Platelets [#/volume] in Blood by Automated count"
    },
    {
      "reference": "https://sandbox-api.va.gov/services/fhir/v0/dstu2/Observation/I2-2Q24OSOGIKOYXMFBLRNLGHA5OE000000",
      "display": "Platelet distribution width [Entitic volume] in Bl"
    },
    {
      "reference": "https://sandbox-api.va.gov/services/fhir/v0/dstu2/Observation/I2-3VQGL64X7STPFZFCYCVKSHF73Y000000",
      "display": "Platelet mean volume [Entitic volume] in Blood by"
    }
  ]
}
```

Medications

```
{
  "resourceType": "MedicationOrder",
  "id": "I2-EB52N3D4X2A4PAVQS5SDWGDOLY000000",
  "dateWritten": "1993-09-06T05:00:00Z",
  "status": "completed",
  "dateEnded": "2012-01-09T06:00:00Z",
  "patient": {
    "reference": "https://sandbox-api.va.gov/services/fhir/v0/dstu2/Patient/36000036",
    "display": "Mr. Ned189 Renner328"
  },
  "_prescriber": {
    "extension": [
      {
        "url": "http://hl7.org/fhir/StructureDefinition/data-absent-reason",
        "valueCode": "unknown"
      }
    ]
  },
  "medicationReference": {
    "reference": "https://sandbox-api.va.gov/services/fhir/v0/dstu2/Medication/I2-OMOTSBLZEQCFCNXDPYFKLTN764000000",
    "display": "Hydrochlorothiazide 6.25 MG"
  },
  "dispenseRequest": {
    "quantity": {
      "value": 1
    },
    "expectedSupplyDuration": {
      "value": 30,
      "unit": "days",
      "system": "http://unitsofmeasure.org",
      "code": "d"
    }
  }
}
```

Medications Statements

```
{
  "resourceType": "MedicationStatement",
  "id": "I2-MFS6FGJ33M7TPUVYGQWVBFMJRU000000",
  "patient": {
    "reference": "https://sandbox-api.va.gov/services/fhir/v0/dstu2/Patient/36000036",
    "display": "Mr. Ned189 Renner328"
  },
  "dateAsserted": "1994-10-13T20:04:03Z",
  "status": "active",
  "effectiveDateTime": "1994-10-13T20:04:03Z",
  "note": "0.3 ML EPINEPHrine 0.5 MG/ML Auto-Injector",
  "medicationReference": {
    "reference": "https://sandbox-api.va.gov/services/fhir/v0/dstu2/Medication/I2-3AJ34NBWLIMHDBNESPQTQTD2BM000000",
    "display": "0.3 ML EPINEPHrine 0.5 MG/ML Auto-Injector"
  },
  "dosage": [
    {
      "text": "Once per day.",
      "timing": {
        "code": {
          "text": "As directed by physician."
        }
      },
      "route": {
        "text": "As directed by physician."
      }
    }
  ]
}
```

Immunizations

```
{
  "resourceType": "Immunization",
  "id": "I2-XYVAHYAROL4ASZSFXU4QFPIZ6I000000",
  "status": "completed",
  "date": "2008-12-22T21:04:03Z",
  "vaccineCode": {
    "coding": [
      {
        "system": "http://hl7.org/fhir/sid/cvx",
        "code": "140"
      }
    ],
    "text": "Influenza  seasonal  injectable  preservative free"
  },
  "patient": {
    "reference": "https://sandbox-api.va.gov/services/fhir/v0/dstu2/Patient/36000036",
    "display": "Mr. Ned189 Renner328"
  },
  "wasNotGiven": false,
  "_reported": {
    "extension": [
      {
        "url": "http://hl7.org/fhir/StructureDefinition/data-absent-reason",
        "valueCode": "unsupported"
      }
    ]
  },
  "note": [
    {
      "text": "Dose #15 of 101 of Influenza  seasonal  injectable  preservative free vaccine administered."
    }
  ],
  "reaction": [
    {
      "detail": {
        "display": "Convulsions"
      }
    }
  ]
}
```

Observations

```
{
  "resourceType": "Observation",
  "id": "I2-ODAPHBLOQCNERD3N75BGNONMLE000000",
  "status": "final",
  "category": {
    "coding": [
      {
        "system": "http://hl7.org/fhir/observation-category",
        "code": "laboratory",
        "display": "Laboratory"
      }
    ]
  },
  "code": {
    "coding": [
      {
        "system": "http://loinc.org",
        "code": "6690-2",
        "display": "Leukocytes [#/volume] in Blood by Automated count"
      }
    ]
  },
  "subject": {
    "reference": "https://sandbox-api.va.gov/services/fhir/v0/dstu2/Patient/36000036",
    "display": "Mr. Ned189 Renner328"
  },
  "effectiveDateTime": "2009-12-28T21:04:03Z",
  "issued": "2009-12-28T21:04:03Z",
  "valueQuantity": {
    "value": 8.650095965775943,
    "unit": "10*3/uL",
    "system": "http://unitsofmeasure.org",
    "code": "10*3/uL"
  }
}

```

Procedures

```
{
  "resourceType": "Procedure",
  "id": "I2-GOAOTIHKYG7AOYNLKACMMREI4Q000000",
  "subject": {
    "reference": "https://sandbox-api.va.gov/services/fhir/v0/dstu2/Patient/36000036",
    "display": "Mr. Ned189 Renner328"
  },
  "status": "completed",
  "code": {
    "coding": [
      {
        "system": "http://www.ama-assn.org/go/cpt",
        "code": "XXXXX",
        "display": "Subcutaneous immunotherapy"
      }
    ]
  },
  "notPerformed": false,
  "performedDateTime": "2008-12-08T21:04:03Z"
}
```
