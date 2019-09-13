namespace Iso8583
{
    using System;
    using System.Collections.Generic;
    using Iso8583.Types;
    using Iso8583.Utils;

    public class Iso8583Message : IIso8583Message
    {
        protected void SetBitmap(int v)
        {
            if (PrimaryBitmap == null)
            {
                PrimaryBitmap = new HashSet<int>();
            }

            if (v < 64)
            {
                PrimaryBitmap.Add(v);
            }
            else
            {
                if (SecondBitmap == null)
                {
                    SecondBitmap = new HashSet<int>();
                }
                // Add using secondary
                PrimaryBitmap.Add(1);
                SecondBitmap.Add(v);
            }
        }

        public override string ToString()
        {
            return null;
        }

        public bool HasBitmap => true;
        public bool HasTypeIndicator => true;

        public decimal TypeIndicator { get; set; }

        public ISet<int> PrimaryBitmap { get; private set; }

        /// <summary>
        /// Second Bitmap
        /// Field 1
        /// Type b64
        /// </summary>
        public ISet<int> SecondBitmap { get; private set; }
        public ISet<int> Field1
        {
            get => SecondBitmap;
        }

        /// <summary>
        /// Primary account number (PAN)
        /// Field 2
        /// Type n..19
        /// </summary>
        [Iso8583Value(
            Number = 2,
            Type = Iso8583DataTypes.NUMERIC,
            LengthType = Iso8583LengthTypes.VARIABLE,
            VariableLengthType = Iso8583VariableLengthTypes.MAX99,
            Length = 19
            )]
        public decimal PrimaryAccountNumber
        {
            get => _primaryAccountNumber;
            set
            {
                SetBitmap(2);
                _primaryAccountNumber = value;
            }
        }
        private decimal _primaryAccountNumber;
        public decimal Field2
        {
            get => PrimaryAccountNumber;
            set => PrimaryAccountNumber = value;
        }

        /// <summary>
        /// Processing code
        /// Field 3
        /// Type n6
        /// </summary>
        [Iso8583Value(
            Number = 3,
            Type = Iso8583DataTypes.NUMERIC,
            LengthType = Iso8583LengthTypes.FIXED,
            Length = 6
            )]
        public decimal Field3
        {
            get => ProcessingCode;
            set => ProcessingCode = value;
        }
        public decimal ProcessingCode
        {
            get => _processingCode;
            set
            {
                SetBitmap(3);
                _processingCode = value;
            }
        }
        private decimal _processingCode;

        /// <summary>
        /// Amount, transaction
        /// Field 4
        /// Type n12
        /// </summary>
        [Iso8583Value(
            Number = 4,
            Type = Iso8583DataTypes.NUMERIC,
            LengthType = Iso8583LengthTypes.FIXED,
            Length = 12
            )]
        public decimal Field4
        {
            get => AmountTransaction;
            set => AmountTransaction = value;
        }
        public decimal AmountTransaction
        {
            get => _amountTransaction;
            set
            {
                SetBitmap(4);
                _amountTransaction = value;
            }
        }
        private decimal _amountTransaction;

        /// <summary>
        /// Amount, settlement
        /// Field 5
        /// Type n12
        /// </summary>
        [Iso8583Value(
            Number = 5,
            Type = Iso8583DataTypes.NUMERIC,
            LengthType = Iso8583LengthTypes.FIXED,
            Length = 12
            )]
        public decimal Field5
        {
            get => AmountSettlement;
            set => AmountSettlement = value;
        }
        public decimal AmountSettlement
        {
            get => _amountSettlement;
            set
            {
                SetBitmap(5);
                _amountSettlement = value;
            }
        }
        private decimal _amountSettlement;

        /// <summary>
        /// Amount, cardholder billing
        /// Field 6
        /// Type n12
        /// </summary>
        [Iso8583Value(
            Number = 6,
            Type = Iso8583DataTypes.NUMERIC,
            LengthType = Iso8583LengthTypes.FIXED,
            Length = 12
            )]
        public decimal Field6
        {
            get => AmountCardholderBilling;
            set => AmountCardholderBilling = value;
        }
        public decimal AmountCardholderBilling
        {
            get => _amountCardholderBilling;
            set
            {
                SetBitmap(6);
                _amountCardholderBilling = value;
            }
        }
        private decimal _amountCardholderBilling;

        /// <summary>
        /// Transmission date & time
        /// Field 7
        /// Type n10
        /// </summary>
        [Iso8583Value(
            Number = 7,
            Type = Iso8583DataTypes.ALPHA,
            LengthType = Iso8583LengthTypes.FIXED,
            Length = 10,
            AlphaHasNumerics = true
            )]
        public string Field7
        {
            get => ConvertDateTime.MMDDhhmmss(TransmissionDateTime);
            set => TransmissionDateTime = ConvertDateTime.MMDDhhmmss(value);
        }
        public DateTime TransmissionDateTime
        {
            get => _transmissionDateTime;
            set
            {
                SetBitmap(7);
                _transmissionDateTime = value;
            }
        }
        private DateTime _transmissionDateTime;

        /// <summary>
        /// Amount, cardholder billing fee
        /// Field 8
        /// Type n8
        /// </summary>
        [Iso8583Value(
            Number = 8,
            Type = Iso8583DataTypes.NUMERIC,
            LengthType = Iso8583LengthTypes.FIXED,
            Length = 8
            )]
        public decimal Field8
        {
            get => AmountCardholderBillingFee;
            set => AmountCardholderBillingFee = value;
        }
        public decimal AmountCardholderBillingFee
        {
            get => _amountCardholderBillingFee;
            set
            {
                SetBitmap(8);
                _amountCardholderBillingFee = value;
            }
        }
        private decimal _amountCardholderBillingFee;

        /// <summary>
        /// Conversion rate, settlement
        /// Field 9
        /// Type n8
        /// </summary>
        [Iso8583Value(
            Number = 9,
            Type = Iso8583DataTypes.NUMERIC,
            LengthType = Iso8583LengthTypes.FIXED,
            Length = 8
            )]
        public decimal Field9
        {
            get => ConversionRateSettlement;
            set => ConversionRateSettlement = value;
        }
        public decimal ConversionRateSettlement
        {
            get => _conversionRateSettlement;
            set
            {
                SetBitmap(9);
                _conversionRateSettlement = value;
            }
        }
        private decimal _conversionRateSettlement;

        /// <summary>
        /// Conversion rate, cardholder billing
        /// Field 10
        /// Type n8
        /// </summary>
        [Iso8583Value(
            Number = 10,
            Type = Iso8583DataTypes.NUMERIC,
            LengthType = Iso8583LengthTypes.FIXED,
            Length = 8
            )]
        public decimal Field10
        {
            get => ConversionRateCardholderBilling;
            set => ConversionRateCardholderBilling = value;
        }
        public decimal ConversionRateCardholderBilling
        {
            get => _conversionRateCardholderBilling;
            set
            {
                SetBitmap(10);
                _conversionRateCardholderBilling = value;
            }
        }
        private decimal _conversionRateCardholderBilling;

        /// <summary>
        /// System trace audit number (STAN)
        /// Field 11
        /// Type n6
        /// </summary>
        [Iso8583Value(
            Number = 11,
            Type = Iso8583DataTypes.NUMERIC,
            LengthType = Iso8583LengthTypes.FIXED,
            Length = 6
            )]
        public decimal Field11
        {
            get => SystemTraceAuditNumber;
            set => SystemTraceAuditNumber = value;
        }
        public decimal SystemTraceAuditNumber
        {
            get => _systemTraceAuditNumber;
            set
            {
                SetBitmap(11);
                _systemTraceAuditNumber = value;
            }
        }
        private decimal _systemTraceAuditNumber;

        /// <summary>
        /// Local transaction time (hhmmss)
        /// Field 12
        /// Type n6
        /// </summary>
        [Iso8583Value(
            Number = 12,
            Type = Iso8583DataTypes.ALPHA,
            LengthType = Iso8583LengthTypes.FIXED,
            Length = 6,
            AlphaHasNumerics = true
            )]
        public string Field12
        {
            get => ConvertDateTime.hhmmss(LocalTransactionTime);
            set => LocalTransactionTime = ConvertDateTime.hhmmss(value);
        }
        public DateTime LocalTransactionTime
        {
            get => _localTransactionTime;
            set
            {
                SetBitmap(12);
                _localTransactionTime = value;
            }
        }
        private DateTime _localTransactionTime;

        /// <summary>
        /// Local transaction date (MMDD)
        /// Field 13
        /// Type n4
        /// </summary>
        [Iso8583Value(
            Number = 13,
            Type = Iso8583DataTypes.ALPHA,
            LengthType = Iso8583LengthTypes.FIXED,
            Length = 4,
            AlphaHasNumerics = true
            )]
        public string Field13
        {
            get => ConvertDateTime.MMDD(LocalTransactionDate);
            set => LocalTransactionDate = ConvertDateTime.MMDD(value);
        }
        public DateTime LocalTransactionDate
        {
            get => _localTransactionDate;
            set
            {
                SetBitmap(13);
                _localTransactionDate = value;
            }
        }
        private DateTime _localTransactionDate;

        /// <summary>
        /// Expiration date
        /// Field 14
        /// Type n4
        /// </summary>
        [Iso8583Value(
            Number = 14,
            Type = Iso8583DataTypes.ALPHA,
            LengthType = Iso8583LengthTypes.FIXED,
            Length = 4,
            AlphaHasNumerics = true
             )]
        public string Field14
        {
            get => ConvertDateTime.yyMM(ExpirationDate);
            set => ExpirationDate = ConvertDateTime.yyMM(value);
        }
        public DateTime ExpirationDate
        {
            get => _expirationDate;
            set
            {
                SetBitmap(14);
                _expirationDate = value;
            }
        }
        private DateTime _expirationDate;

        /// <summary>
        /// Settlement date
        /// Field 15
        /// Type n4
        /// </summary>
        [Iso8583Value(
            Number = 15,
            Type = Iso8583DataTypes.NUMERIC,
            LengthType = Iso8583LengthTypes.FIXED,
            Length = 4
            )]
        public decimal Field15
        {
            get => SettlementDate;
            set => SettlementDate = value;
        }
        public decimal SettlementDate
        {
            get => _settlementDate;
            set
            {
                SetBitmap(15);
                _settlementDate = value;
            }
        }
        private decimal _settlementDate;

        /// <summary>
        /// 
        /// Field 16
        /// Type n4
        /// </summary>
        [Iso8583Value(
            Number = 16,
            Type = Iso8583DataTypes.ALPHA,
            LengthType = Iso8583LengthTypes.FIXED,
            Length = 4,
            AlphaHasNumerics = true
            )]
        public string Field16
        {
            get => ConvertDateTime.MMDD(CurrencyConversionDate);
            set => CurrencyConversionDate = ConvertDateTime.MMDD(value);
        }
        public DateTime CurrencyConversionDate
        {
            get => _currencyConversionDate;
            set
            {
                SetBitmap(16);
                _currencyConversionDate = value;
            }
        }
        private DateTime _currencyConversionDate;

        /// <summary>
        /// Capture date
        /// Field 17
        /// Type n4
        /// </summary>
        [Iso8583Value(
            Number = 17,
            Type = Iso8583DataTypes.NUMERIC,
            LengthType = Iso8583LengthTypes.FIXED,
            Length = 4
            )]
        public decimal Field17
        {
            get => CaptureDate;
            set => CaptureDate = value;
        }
        public decimal CaptureDate
        {
            get => _captureDate;
            set
            {
                SetBitmap(17);
                _captureDate = value;
            }
        }
        private decimal _captureDate;

        /// <summary>
        /// Merchant type, or merchant category code
        /// Field 18
        /// Type n4
        /// </summary>
        [Iso8583Value(
            Number = 18,
            Type = Iso8583DataTypes.NUMERIC,
            LengthType = Iso8583LengthTypes.FIXED,
            Length = 4
            )]
        public decimal Field18
        {
            get => MerchantTypeOrMerchantCategoryCode;
            set => MerchantTypeOrMerchantCategoryCode = value;
        }
        public decimal MerchantTypeOrMerchantCategoryCode
        {
            get => _merchantTypeOrMerchantCategoryCode;
            set
            {
                SetBitmap(18);
                _merchantTypeOrMerchantCategoryCode = value;
            }
        }
        private decimal _merchantTypeOrMerchantCategoryCode;

        /// <summary>
        /// Acquiring institution (country code)
        /// Field 19
        /// Type n3
        /// </summary>
        [Iso8583Value(
            Number = 19,
            Type = Iso8583DataTypes.NUMERIC,
            LengthType = Iso8583LengthTypes.FIXED,
            Length = 3
            )]
        public decimal Field19
        {
            get => AcquiringInstitution;
            set => AcquiringInstitution = value;
        }
        public decimal AcquiringInstitution
        {
            get => _acquiringInstitution;
            set
            {
                SetBitmap(19);
                _acquiringInstitution = value;
            }
        }
        private decimal _acquiringInstitution;

        /// <summary>
        /// Primary account number (PAN) extended (country code)
        /// Field 20
        /// Type n3
        /// </summary>
        [Iso8583Value(
            Number = 20,
            Type = Iso8583DataTypes.NUMERIC,
            LengthType = Iso8583LengthTypes.FIXED,
            Length = 3
            )]
        public decimal Field20
        {
            get => PrimaryAccountNumberExtendedCountryCode;
            set => PrimaryAccountNumberExtendedCountryCode = value;
        }
        public decimal PrimaryAccountNumberExtendedCountryCode
        {
            get => _primaryAccountNumberExtendedCountryCode;
            set
            {
                SetBitmap(20);
                _primaryAccountNumberExtendedCountryCode = value;
            }
        }
        private decimal _primaryAccountNumberExtendedCountryCode;

        /// <summary>
        /// Forwarding institution (country code)
        /// Field 21
        /// Type n3
        /// </summary>
        [Iso8583Value(
            Number = 21,
            Type = Iso8583DataTypes.NUMERIC,
            LengthType = Iso8583LengthTypes.FIXED,
            Length = 3
            )]
        public decimal Field21
        {
            get => ForwardingInstitution;
            set => ForwardingInstitution = value;
        }
        public decimal ForwardingInstitution
        {
            get => _forwardingInstitution;
            set
            {
                SetBitmap(21);
                _forwardingInstitution = value;
            }
        }
        private decimal _forwardingInstitution;

        /// <summary>
        /// Point of service entry mode
        /// Field 22
        /// Type n3
        /// </summary>
        [Iso8583Value(
            Number = 22,
            Type = Iso8583DataTypes.NUMERIC,
            LengthType = Iso8583LengthTypes.FIXED,
            Length = 3
            )]
        public decimal Field22
        {
            get => PointOfServiceEntryMode;
            set => PointOfServiceEntryMode = value;
        }
        public decimal PointOfServiceEntryMode
        {
            get => _pointOfServiceEntryMode;
            set
            {
                SetBitmap(22);
                _pointOfServiceEntryMode = value;
            }
        }
        private decimal _pointOfServiceEntryMode;

        /// <summary>
        /// Application primary account number (PAN) sequence number
        /// Field 23
        /// Type n3
        /// </summary>
        [Iso8583Value(
            Number = 23,
            Type = Iso8583DataTypes.NUMERIC,
            LengthType = Iso8583LengthTypes.FIXED,
            Length = 3
            )]
        public decimal Field23
        {
            get => ApplicationPrimaryAccountNumberSequenceNumber;
            set => ApplicationPrimaryAccountNumberSequenceNumber = value;
        }
        public decimal ApplicationPrimaryAccountNumberSequenceNumber
        {
            get => _applicationPrimaryAccountNumberSequenceNumber;
            set
            {
                SetBitmap(23);
                _applicationPrimaryAccountNumberSequenceNumber = value;
            }
        }
        private decimal _applicationPrimaryAccountNumberSequenceNumber;

        /// <summary>
        /// Function code (ISO 8583:1993), or network international identifier (NII)
        /// Field 24
        /// Type n3
        /// </summary>
        [Iso8583Value(
            Number = 24,
            Type = Iso8583DataTypes.NUMERIC,
            LengthType = Iso8583LengthTypes.FIXED,
            Length = 3
            )]
        public decimal Field24
        {
            get => FunctionCodeOrNetworkInternationalIdentifier;
            set => FunctionCodeOrNetworkInternationalIdentifier = value;
        }
        public decimal FunctionCodeOrNetworkInternationalIdentifier
        {
            get => _functionCodeOrNetworkInternationalIdentifier;
            set
            {
                SetBitmap(24);
                _functionCodeOrNetworkInternationalIdentifier = value;
            }
        }
        private decimal _functionCodeOrNetworkInternationalIdentifier;

        /// <summary>
        /// Point of service condition code
        /// Field 25
        /// Type n2
        /// </summary>
        [Iso8583Value(
            Number = 25,
            Type = Iso8583DataTypes.NUMERIC,
            LengthType = Iso8583LengthTypes.FIXED,
            Length = 2
            )]
        public decimal Field25
        {
            get => PointOfServiceConditionCode;
            set => PointOfServiceConditionCode = value;
        }
        public decimal PointOfServiceConditionCode
        {
            get => _pointOfServiceConditionCode;
            set
            {
                SetBitmap(25);
                _pointOfServiceConditionCode = value;
            }
        }
        private decimal _pointOfServiceConditionCode;

        /// <summary>
        /// Point of service capture code
        /// Field 26
        /// Type n2
        /// </summary>
        [Iso8583Value(
            Number = 26,
            Type = Iso8583DataTypes.NUMERIC,
            LengthType = Iso8583LengthTypes.FIXED,
            Length = 2
            )]
        public decimal Field26
        {
            get => PointOfServiceCaptureCode;
            set => PointOfServiceCaptureCode = value;
        }
        public decimal PointOfServiceCaptureCode
        {
            get => _pointOfServiceCaptureCode;
            set
            {
                SetBitmap(26);
                _pointOfServiceCaptureCode = value;
            }
        }
        private decimal _pointOfServiceCaptureCode;

        /// <summary>
        /// Authorizing identification response length
        /// Field 27
        /// Type n1
        /// </summary>
        [Iso8583Value(
            Number = 27,
            Type = Iso8583DataTypes.NUMERIC,
            LengthType = Iso8583LengthTypes.FIXED,
            Length = 1
            )]
        public decimal Field27
        {
            get => AuthorizingIdentificationResponseLength;
            set => AuthorizingIdentificationResponseLength = value;
        }
        public decimal AuthorizingIdentificationResponseLength
        {
            get => _authorizingIdentificationResponseLength;
            set
            {
                SetBitmap(27);
                _authorizingIdentificationResponseLength = value;
            }
        }
        private decimal _authorizingIdentificationResponseLength;

        /// <summary>
        /// Amount, transaction fee
        /// Field 28
        /// Type x+n8
        /// </summary>
        [Iso8583Value(
            Number = 28,
            Type = Iso8583DataTypes.NUMERIC,
            LengthType = Iso8583LengthTypes.FIXED,
            Length = 8,
            NumericHasSigne = true
            )]
        public decimal Field28
        {
            get => AmountTransactionFee;
            set => AmountTransactionFee = value;
        }
        public decimal AmountTransactionFee
        {
            get => _amountTransactionFee;
            set
            {
                SetBitmap(28);
                _amountTransactionFee = value;
            }
        }
        private decimal _amountTransactionFee;

        /// <summary>
        /// Amount, settlement fee
        /// Field 29
        /// Type x+n8
        /// </summary>
        [Iso8583Value(
            Number = 29,
            Type = Iso8583DataTypes.NUMERIC,
            LengthType = Iso8583LengthTypes.FIXED,
            Length = 8,
            NumericHasSigne = true
            )]
        public decimal Field29
        {
            get => AmountSettlementFee;
            set => AmountSettlementFee = value;
        }
        public decimal AmountSettlementFee
        {
            get => _amountSettlementFee;
            set
            {
                SetBitmap(29);
                _amountSettlementFee = value;
            }
        }
        private decimal _amountSettlementFee;

        /// <summary>
        /// Amount, transaction processing fee
        /// Field 30
        /// Type x+n8
        /// </summary>
        [Iso8583Value(
            Number = 30,
            Type = Iso8583DataTypes.NUMERIC,
            LengthType = Iso8583LengthTypes.FIXED,
            Length = 8,
            NumericHasSigne = true
            )]
        public decimal Field30
        {
            get => AmountTransactionProcessingFee;
            set => AmountTransactionProcessingFee = value;
        }
        public decimal AmountTransactionProcessingFee
        {
            get => _amountTransactionProcessingFee;
            set
            {
                SetBitmap(30);
                _amountTransactionProcessingFee = value;
            }
        }
        private decimal _amountTransactionProcessingFee;

        /// <summary>
        /// Amount, settlement processing fee
        /// Field 31
        /// Type x+n8
        /// </summary>
        [Iso8583Value(
            Number = 31,
            Type = Iso8583DataTypes.NUMERIC,
            LengthType = Iso8583LengthTypes.FIXED,
            Length = 8,
            NumericHasSigne = true
            )]
        public decimal Field31
        {
            get => AmountSettlementProcessingFee;
            set => AmountSettlementProcessingFee = value;
        }
        public decimal AmountSettlementProcessingFee
        {
            get => _amountSettlementProcessingFee;
            set
            {
                SetBitmap(31);
                _amountSettlementProcessingFee = value;
            }
        }
        private decimal _amountSettlementProcessingFee;

        /// <summary>
        /// Acquiring institution identification code
        /// Field 32
        /// Type n..11
        /// </summary>
        [Iso8583Value(
            Number = 32,
            Type = Iso8583DataTypes.NUMERIC,
            LengthType = Iso8583LengthTypes.VARIABLE,
            Length = 11,
            VariableLengthType = Iso8583VariableLengthTypes.MAX99
            )]
        public decimal Field32
        {
            get => AcquiringInstitutionIdentificationCode;
            set => AcquiringInstitutionIdentificationCode = value;
        }
        public decimal AcquiringInstitutionIdentificationCode
        {
            get => _acquiringInstitutionIdentificationCode;
            set
            {
                SetBitmap(32);
                _acquiringInstitutionIdentificationCode = value;
            }
        }
        private decimal _acquiringInstitutionIdentificationCode;

        /// <summary>
        /// Forwarding institution identification code
        /// Field 33
        /// Type n..11
        /// </summary>
        [Iso8583Value(
            Number = 33,
            Type = Iso8583DataTypes.NUMERIC,
            LengthType = Iso8583LengthTypes.VARIABLE,
            Length = 11,
            VariableLengthType = Iso8583VariableLengthTypes.MAX99
            )]
        public decimal Field33
        {
            get => ForwardingInstitutionIdentificationCode;
            set => ForwardingInstitutionIdentificationCode = value;
        }
        public decimal ForwardingInstitutionIdentificationCode
        {
            get => _forwardingInstitutionIdentificationCode;
            set
            {
                SetBitmap(33);
                _forwardingInstitutionIdentificationCode = value;
            }
        }
        private decimal _forwardingInstitutionIdentificationCode;

        /// <summary>
        /// Forwarding institution identification code
        /// Field 34
        /// Type ns..28
        /// </summary>
        [Iso8583Value(
            Number = 34,
            Type = Iso8583DataTypes.ALPHA,
            LengthType = Iso8583LengthTypes.VARIABLE,
            Length = 28,
            VariableLengthType = Iso8583VariableLengthTypes.MAX99,
            AlphaHasNumerics = true,
            AlphaHasSpecialChars = true
            )]
        public string Field34
        {
            get => PrimaryAccountNumberExtended;
            set => PrimaryAccountNumberExtended = value;
        }
        public string PrimaryAccountNumberExtended
        {
            get => _primaryAccountNumberExtended;
            set
            {
                SetBitmap(34);
                _primaryAccountNumberExtended = value;
            }
        }
        private string _primaryAccountNumberExtended;

        /// <summary>
        /// Track 2 data
        /// Field 35
        /// Type z..37
        /// </summary>
        [Iso8583Value(
            Number = 35,
            Type = Iso8583DataTypes.ALPHA,
            LengthType = Iso8583LengthTypes.VARIABLE,
            Length = 37,
            VariableLengthType = Iso8583VariableLengthTypes.MAX99,
            AlphaHasNumerics = true,
            AlphaHasSpecialChars = true
            )]
        public string Field35
        {
            get => Track2Data;
            set => Track2Data = value;
        }
        public string Track2Data
        {
            get => _track2Data;
            set
            {
                SetBitmap(35);
                _track2Data = value;
            }
        }
        private string _track2Data;

        /// <summary>
        /// Track 3 data
        /// Field 36
        /// Type ns..104
        /// </summary>
        [Iso8583Value(
            Number = 36,
            Type = Iso8583DataTypes.ALPHA,
            LengthType = Iso8583LengthTypes.VARIABLE,
            Length = 104,
            VariableLengthType = Iso8583VariableLengthTypes.MAX999,
            AlphaHasNumerics = true,
            AlphaHasSpecialChars = true
            )]
        public string Field36
        {
            get => Track3Data;
            set => Track3Data = value;
        }
        public string Track3Data
        {
            get => _track3Data;
            set
            {
                SetBitmap(36);
                _track3Data = value;
            }
        }
        private string _track3Data;

        /// <summary>
        /// Retrieval reference number
        /// Field 37
        /// Type an12
        /// </summary>
        [Iso8583Value(
            Number = 37,
            Type = Iso8583DataTypes.ALPHA,
            LengthType = Iso8583LengthTypes.FIXED,
            Length = 12,
            AlphaHasLetters = true,
            AlphaHasNumerics = true
            )]
        public string Field37
        {
            get => RetrievalReferenceNumber;
            set => RetrievalReferenceNumber = value;
        }
        public string RetrievalReferenceNumber
        {
            get => _retrievalReferenceNumber;
            set
            {
                SetBitmap(37);
                _retrievalReferenceNumber = value;
            }
        }
        private string _retrievalReferenceNumber;

        /// <summary>
        /// Authorization identification response
        /// Field 38
        /// Type an6
        /// </summary>
        [Iso8583Value(
            Number = 38,
            Type = Iso8583DataTypes.ALPHA,
            LengthType = Iso8583LengthTypes.FIXED,
            Length = 6,
            AlphaHasLetters = true,
            AlphaHasNumerics = true
            )]
        public string Field38
        {
            get => AuthorizationIdentificationResponse;
            set => AuthorizationIdentificationResponse = value;
        }
        public string AuthorizationIdentificationResponse
        {
            get => _authorizationIdentificationResponse;
            set
            {
                SetBitmap(38);
                _authorizationIdentificationResponse = value;
            }
        }
        private string _authorizationIdentificationResponse;

        /// <summary>
        /// Response code
        /// Field 39
        /// Type an2
        /// </summary>
        [Iso8583Value(
            Number = 39,
            Type = Iso8583DataTypes.ALPHA,
            LengthType = Iso8583LengthTypes.FIXED,
            Length = 2,
            AlphaHasLetters = true,
            AlphaHasNumerics = true
            )]
        public string Field39
        {
            get => ResponseCode;
            set => ResponseCode = value;
        }
        public string ResponseCode
        {
            get => _responseCode;
            set
            {
                SetBitmap(39);
                _responseCode = value;
            }
        }
        private string _responseCode;

        /// <summary>
        /// Service restriction code
        /// Field 40
        /// Type an3
        /// </summary>
        [Iso8583Value(
            Number = 40,
            Type = Iso8583DataTypes.ALPHA,
            LengthType = Iso8583LengthTypes.FIXED,
            Length = 3,
            AlphaHasLetters = true,
            AlphaHasNumerics = true
            )]
        public string Field40
        {
            get => ServiceRestrictionCode;
            set => ServiceRestrictionCode = value;
        }
        public string ServiceRestrictionCode
        {
            get => _serviceRestrictionCode;
            set
            {
                SetBitmap(40);
                _serviceRestrictionCode = value;
            }
        }
        private string _serviceRestrictionCode;

        /// <summary>
        /// Card acceptor terminal identification
        /// Field 41
        /// Type ans8
        /// </summary>
        [Iso8583Value(
            Number = 41,
            Type = Iso8583DataTypes.ALPHA,
            LengthType = Iso8583LengthTypes.FIXED,
            Length = 8,
            AlphaHasLetters = true,
            AlphaHasNumerics = true,
            AlphaHasSpecialChars = true
            )]
        public string Field41
        {
            get => CardAceptorTerminalIdentification;
            set => CardAceptorTerminalIdentification = value;
        }
        public string CardAceptorTerminalIdentification
        {
            get => _cardAceptorTerminalIdentification;
            set
            {
                SetBitmap(41);
                _cardAceptorTerminalIdentification = value;
            }
        }
        private string _cardAceptorTerminalIdentification;

        /// <summary>
        /// Card acceptor terminal identification
        /// Field 42
        /// Type ans15
        /// </summary>
        [Iso8583Value(
            Number = 42,
            Type = Iso8583DataTypes.ALPHA,
            LengthType = Iso8583LengthTypes.FIXED,
            Length = 15,
            AlphaHasLetters = true,
            AlphaHasNumerics = true,
            AlphaHasSpecialChars = true
            )]
        public string Field42
        {
            get => CardAcceptorIdentificationCode;
            set => CardAcceptorIdentificationCode = value;
        }
        public string CardAcceptorIdentificationCode
        {
            get => _cardAcceptorIdentificationCode;
            set
            {
                SetBitmap(42);
                _cardAcceptorIdentificationCode = value;
            }
        }
        private string _cardAcceptorIdentificationCode;

        /// <summary>
        /// Card acceptor name/location (1-23 street address, 24-36 city, 37-38 state, 39-40 country)
        /// Field 43
        /// Type ans40
        /// </summary>
        [Iso8583Value(
            Number = 43,
            Type = Iso8583DataTypes.ALPHA,
            LengthType = Iso8583LengthTypes.FIXED,
            Length = 40,
            AlphaHasLetters = true,
            AlphaHasNumerics = true,
            AlphaHasSpecialChars = true,
            Truncate = true
            )]
        public string Field43
        {
            get => CardAcceptorNameLocation;
            set => CardAcceptorNameLocation = value;
        }
        public string CardAcceptorNameLocation
        {
            get => _cardAcceptorNameLocation;
            set
            {
                SetBitmap(43);
                _cardAcceptorNameLocation = value;
            }
        }
        private string _cardAcceptorNameLocation;

        /// <summary>
        /// Additional response data
        /// Field 44
        /// Type an..25
        /// </summary>
        [Iso8583Value(
            Number = 44,
            Type = Iso8583DataTypes.ALPHA,
            LengthType = Iso8583LengthTypes.VARIABLE,
            VariableLengthType = Iso8583VariableLengthTypes.MAX99,
            Length = 25,
            AlphaHasLetters = true,
            AlphaHasNumerics = true
            )]
        public string Field44
        {
            get => AdditionalResponseData;
            set => AdditionalResponseData = value;
        }
        public string AdditionalResponseData
        {
            get => _additionalResponseData;
            set
            {
                SetBitmap(44);
                _additionalResponseData = value;
            }
        }
        private string _additionalResponseData;

        /// <summary>
        /// Track 1 data
        /// Field 45
        /// Type ans..76
        /// </summary>
        [Iso8583Value(
            Number = 45,
            Type = Iso8583DataTypes.ALPHA,
            LengthType = Iso8583LengthTypes.VARIABLE,
            VariableLengthType = Iso8583VariableLengthTypes.MAX99,
            Length = 76,
            AlphaHasLetters = true,
            AlphaHasNumerics = true,
            AlphaHasSpecialChars = true
            )]
        public string Field45
        {
            get => Track1Data;
            set => Track1Data = value;
        }
        public string Track1Data
        {
            get => _track1Data;
            set
            {
                SetBitmap(45);
                _track1Data = value;
            }
        }
        private string _track1Data;

        /// <summary>
        /// Additional data (ISO)
        /// Field 46
        /// Type an...999
        /// </summary>
        [Iso8583Value(
            Number = 46,
            Type = Iso8583DataTypes.ALPHA,
            LengthType = Iso8583LengthTypes.VARIABLE,
            VariableLengthType = Iso8583VariableLengthTypes.MAX999,
            Length = 999,
            AlphaHasLetters = true,
            AlphaHasNumerics = true
            )]
        public string Field46
        {
            get => AdditionalDataIso;
            set => AdditionalDataIso = value;
        }
        public string AdditionalDataIso
        {
            get => _additionalDataIso;
            set
            {
                SetBitmap(46);
                _additionalDataIso = value;
            }
        }
        private string _additionalDataIso;

        /// <summary>
        /// Additional data (national)
        /// Field 47
        /// Type an...999
        /// </summary>
        [Iso8583Value(
            Number = 47,
            Type = Iso8583DataTypes.ALPHA,
            LengthType = Iso8583LengthTypes.VARIABLE,
            VariableLengthType = Iso8583VariableLengthTypes.MAX999,
            Length = 999,
            AlphaHasLetters = true,
            AlphaHasNumerics = true
            )]
        public string Field47
        {
            get => AdditionalDataNational;
            set => AdditionalDataNational = value;
        }
        public string AdditionalDataNational
        {
            get => _additionalDataNational;
            set
            {
                SetBitmap(47);
                _additionalDataNational = value;
            }
        }
        private string _additionalDataNational;

        /// <summary>
        /// Additional data (private)
        /// Field 48
        /// Type an...999
        /// </summary>
        [Iso8583Value(
            Number = 48,
            Type = Iso8583DataTypes.ALPHA,
            LengthType = Iso8583LengthTypes.VARIABLE,
            VariableLengthType = Iso8583VariableLengthTypes.MAX999,
            Length = 999,
            AlphaHasLetters = true,
            AlphaHasNumerics = true
            )]
        public string Field48
        {
            get => AdditionalDataPrivate;
            set => AdditionalDataPrivate = value;
        }
        public string AdditionalDataPrivate
        {
            get => _additionalDataPrivate;
            set
            {
                SetBitmap(48);
                _additionalDataPrivate = value;
            }
        }
        private string _additionalDataPrivate;

        /// <summary>
        /// Additional data (private)
        /// Field 49
        /// Type an3
        /// </summary>
        [Iso8583Value(
            Number = 49,
            Type = Iso8583DataTypes.ALPHA,
            LengthType = Iso8583LengthTypes.FIXED,
            Length = 3,
            AlphaHasLetters = true,
            AlphaHasNumerics = true
            )]
        public string Field49
        {
            get => CurrencyCodeTransaction;
            set => CurrencyCodeTransaction = value;
        }
        public string CurrencyCodeTransaction
        {
            get => _currencyCodeTransaction;
            set
            {
                SetBitmap(49);
                _currencyCodeTransaction = value;
            }
        }
        private string _currencyCodeTransaction;

        /// <summary>
        /// Currency code, settlement
        /// Field 50
        /// Type an3
        /// </summary>
        [Iso8583Value(
            Number = 50,
            Type = Iso8583DataTypes.ALPHA,
            LengthType = Iso8583LengthTypes.FIXED,
            Length = 3,
            AlphaHasLetters = true,
            AlphaHasNumerics = true
            )]
        public string Field50
        {
            get => CurrencyCodeSettlement;
            set => CurrencyCodeSettlement = value;
        }
        public string CurrencyCodeSettlement
        {
            get => _currencyCodeSettlement;
            set
            {
                SetBitmap(50);
                _currencyCodeSettlement = value;
            }
        }
        private string _currencyCodeSettlement;

        /// <summary>
        /// Currency code, cardholder billing
        /// Field 51
        /// Type an3
        /// </summary>
        [Iso8583Value(
            Number = 51,
            Type = Iso8583DataTypes.ALPHA,
            LengthType = Iso8583LengthTypes.FIXED,
            Length = 3,
            AlphaHasLetters = true,
            AlphaHasNumerics = true
            )]
        public string Field51
        {
            get => CurrencyCodeCardholderBilling;
            set => CurrencyCodeCardholderBilling = value;
        }
        public string CurrencyCodeCardholderBilling
        {
            get => _currencyCodeCardholderBilling;
            set
            {
                SetBitmap(51);
                _currencyCodeCardholderBilling = value;
            }
        }
        private string _currencyCodeCardholderBilling;

        /// <summary>
        /// Personal identification number data
        /// Field 52
        /// Type b8
        /// </summary>
        [Iso8583Value(
            Number = 52,
            Type = Iso8583DataTypes.BINARY,
            LengthType = Iso8583LengthTypes.FIXED,
            Length = 8
            )]
        public IEnumerable<byte> Field52
        {
            get => PersonalIdentificationNumberData;
            set => PersonalIdentificationNumberData = value;
        }
        public IEnumerable<byte> PersonalIdentificationNumberData
        {
            get => _personalIdentificationNumberData;
            set
            {
                SetBitmap(52);
                _personalIdentificationNumberData = value;
            }
        }
        private IEnumerable<byte> _personalIdentificationNumberData;

        /// <summary>
        /// Security related control information
        /// Field 53
        /// Type n16
        /// </summary>
        [Iso8583Value(
            Number = 53,
            Type = Iso8583DataTypes.NUMERIC,
            LengthType = Iso8583LengthTypes.FIXED,
            Length = 16
            )]
        public decimal Field53
        {
            get => SecurityRelatedControlInformation;
            set => SecurityRelatedControlInformation = value;
        }
        public decimal SecurityRelatedControlInformation
        {
            get => _securityRelatedControlInformation;
            set
            {
                SetBitmap(53);
                _securityRelatedControlInformation = value;
            }
        }
        private decimal _securityRelatedControlInformation;

        /// <summary>
        /// Additional amounts
        /// Field 54
        /// Type an...120
        /// </summary>
        [Iso8583Value(
            Number = 54,
            Type = Iso8583DataTypes.ALPHA,
            LengthType = Iso8583LengthTypes.VARIABLE,
            Length = 120
            )]
        public string Field54
        {
            get => AdditionalAmounts;
            set => AdditionalAmounts = value;
        }
        public string AdditionalAmounts
        {
            get => _additionalAmounts;
            set
            {
                SetBitmap(54);
                _additionalAmounts = value;
            }
        }
        private string _additionalAmounts;

        /// <summary>
        /// ICC data – EMV having multiple tags
        /// Field 55
        /// Type ans...999
        /// </summary>
        [Iso8583Value(
            Number = 55,
            Type = Iso8583DataTypes.ALPHA,
            LengthType = Iso8583LengthTypes.VARIABLE,
            Length = 999,
            VariableLengthType = Iso8583VariableLengthTypes.MAX999
            )]
        public string Field55
        {
            get => IccData;
            set => IccData = value;
        }
        public string IccData
        {
            get => _iccData;
            set
            {
                SetBitmap(55);
                _iccData = value;
            }
        }
        private string _iccData;

        /// <summary>
        /// Reserved (ISO)
        /// Field 56
        /// Type ans...999
        /// </summary>
        [Iso8583Value(
            Number = 56,
            Type = Iso8583DataTypes.ALPHA,
            LengthType = Iso8583LengthTypes.VARIABLE,
            Length = 999,
            VariableLengthType = Iso8583VariableLengthTypes.MAX999
            )]
        public string Field56
        {
            get => _field56;
            set
            {
                SetBitmap(56);
                _field56 = value;
            }
        }
        private string _field56;

        /// <summary>
        /// Reserved (national)
        /// Field 57
        /// Type ans...999
        /// </summary>
        [Iso8583Value(
            Number = 57,
            Type = Iso8583DataTypes.ALPHA,
            LengthType = Iso8583LengthTypes.VARIABLE,
            Length = 999,
            VariableLengthType = Iso8583VariableLengthTypes.MAX999
            )]
        public string Field57
        {
            get => _field57;
            set
            {
                SetBitmap(57);
                _field57 = value;
            }
        }
        private string _field57;

        /// <summary>
        /// Reserved (national)
        /// Field 58
        /// Type ans...999
        /// </summary>
        [Iso8583Value(
            Number = 58,
            Type = Iso8583DataTypes.ALPHA,
            LengthType = Iso8583LengthTypes.VARIABLE,
            Length = 999,
            VariableLengthType = Iso8583VariableLengthTypes.MAX999
            )]
        public string Field58
        {
            get => _field58;
            set
            {
                SetBitmap(58);
                _field58 = value;
            }
        }
        private string _field58;

        /// <summary>
        /// Reserved (national)
        /// Field 59
        /// Type ans...999
        /// </summary>
        [Iso8583Value(
            Number = 59,
            Type = Iso8583DataTypes.ALPHA,
            LengthType = Iso8583LengthTypes.VARIABLE,
            Length = 999,
            VariableLengthType = Iso8583VariableLengthTypes.MAX999
            )]
        public string Field59
        {
            get => _field59;
            set
            {
                SetBitmap(59);
                _field59 = value;
            }
        }
        private string _field59;

        /// <summary>
        /// Reserved (national)
        /// (e.g. settlement request:
        /// batch number,
        /// advice transactions: original transaction amount,
        /// batch upload: original MTI plus original RRN plus original STAN, etc)
        /// Field 60
        /// Type ans...999
        /// </summary>
        [Iso8583Value(
            Number = 60,
            Type = Iso8583DataTypes.ALPHA,
            LengthType = Iso8583LengthTypes.VARIABLE,
            Length = 999,
            VariableLengthType = Iso8583VariableLengthTypes.MAX999
            )]
        public string Field60
        {
            get => _field60;
            set
            {
                SetBitmap(60);
                _field60 = value;
            }
        }
        private string _field60;

        /// <summary>
        /// Reserved (private) (e.g. CVV2/service code   transactions)
        /// Field 61
        /// Type ans...999
        /// </summary>
        [Iso8583Value(
            Number = 61,
            Type = Iso8583DataTypes.ALPHA,
            LengthType = Iso8583LengthTypes.VARIABLE,
            Length = 999,
            VariableLengthType = Iso8583VariableLengthTypes.MAX999
            )]
        public string Field61
        {
            get => _field61;
            set
            {
                SetBitmap(61);
                _field61 = value;
            }
        }
        private string _field61;

        /// <summary>
        /// 	Reserved (private) (e.g. transactions: invoice number, key exchange transactions: TPK key, etc.)
        /// Field 62
        /// Type ans...999
        /// </summary>
        [Iso8583Value(
            Number = 62,
            Type = Iso8583DataTypes.ALPHA,
            LengthType = Iso8583LengthTypes.VARIABLE,
            Length = 999,
            VariableLengthType = Iso8583VariableLengthTypes.MAX999
            )]
        public string Field62
        {
            get => _field62;
            set
            {
                SetBitmap(62);
                _field62 = value;
            }
        }
        private string _field62;

        /// <summary>
        /// Reserved (private)
        /// Field 63
        /// Type ans...999
        /// </summary>
        [Iso8583Value(
            Number = 63,
            Type = Iso8583DataTypes.ALPHA,
            LengthType = Iso8583LengthTypes.VARIABLE,
            Length = 999,
            VariableLengthType = Iso8583VariableLengthTypes.MAX999
            )]
        public string Field63
        {
            get => _field63;
            set
            {
                SetBitmap(63);
                _field63 = value;
            }
        }
        private string _field63;

        /// <summary>
        /// Message authentication code (MAC)
        /// Field 64
        /// Type b8
        /// </summary>
        [Iso8583Value(
            Number = 64,
            Type = Iso8583DataTypes.BINARY,
            LengthType = Iso8583LengthTypes.FIXED,
            Length = 8
            )]
        public IEnumerable<byte> Field64
        {
            get => MessageAuthenticationCode;
            set => MessageAuthenticationCode = value;
        }
        public IEnumerable<byte> MessageAuthenticationCode
        {
            get => _messageAuthenticationCode;
            set
            {
                SetBitmap(64);
                _messageAuthenticationCode = value;
            }
        }
        private IEnumerable<byte> _messageAuthenticationCode;
    }
}
