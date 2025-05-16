Module Variables

    Public LoggedInUser As String
    Public Retry As integer

    'Ito yung original na locktime, ito yung mailalagay sa database
    Public RemainingLockTime As Integer

    'Ito naman yung natitirang time sa form lock
    Public NewLockTime As Integer

    Public CurrrentDate As Date = Date.Now
    Public LastMonth As String = DateTime.Now.AddMonths(-1).Month.ToString()
    Public CurrentMonth As String = DateTime.Now.Month.ToString()
    Public CurrentYear As String = DateTime.Now.Year.ToString()

    'Image Placeholder
    Public ImagePlaceholder As Image = My.Resources.ProductPlaceholder

    'Product Management
    Public ProductImage As Byte()
    Public ProductImageName As String
    Public ProductCategory As Integer? = Nothing
    Public ProductName As String
    Public ProductCode As String
    Public ProductDescription As String
    Public Capital As String
    Public WholeSalePrice As String
    Public RetailPrice As String
    Public Supplier As Integer? = Nothing
    Public MinStock As String
    Public MaxStock As String
    Public AddedBy As Integer

    Public ListOfProductId As New List(Of Integer)
    Public ListOfProductName As New List(Of String)
    Public ListOfProductImage As New List(Of Byte())
    Public ListOfProductCategory As New List(Of Integer)
    Public ListOfProductBarcodeSequence As New List(Of String)
    Public ListOfProductDescription As New List(Of String)
    Public ListOfProductCapital As New List(Of Double)
    Public ListOfProductWholeSalePrice As New List(Of Double)
    Public ListOfProductRetailPrice As New List(Of Double)
    Public ListOfProductMinStock As New List(Of Integer)
    Public ListOfProductMaxStock As New List(Of Integer)
    Public ListOfProductSupplier As New List(Of Integer)
    Public ListOfProductDateAdded As New List(Of String)
    Public ListOfProductTimeAdded As New List(Of String)
    Public ListOfProductAddedBy As New List(Of Integer)

    Public SearchByProductId As New List(Of Integer)
    Public SearchByProductName As New List(Of String)
    Public SearchByProductImage As New List(Of Byte())

    Public NumberOfFilters As Integer
    Public FilterBy As String
    Public FilterByWhat As String
    Public ByDate As String
    Public SortBy As String


    'Stock Management
    Public StockProductId As Integer? = Nothing
    Public StockBatch As String
    Public StockExpiration As String
    Public CurrentStock As Integer? = Nothing
    Public StockWarehouseId As Integer? = Nothing

    Public ListOfStockId As New List(Of Integer)
    Public ListOfStockProductId As New List(Of Integer)
    Public ListOfBatchCode As New List(Of String)
    Public ListOfExpiration As New List(Of String)
    Public ListOfCurrentStock As New List(Of Integer)
    Public ListOfWarehouse As New List(Of Integer)
    Public ListOfStockDateAdded As New List(Of String)
    Public ListOfStockTimeAdded As New List(Of String)

    Public SearchByStockId As New List(Of Integer)
    Public SearchByStockProductId As New List(Of Integer)
    Public SearchBatchCode As New List(Of String)
    Public SearchCurrentStock As New List(Of Integer)

    Public StockNumberOfFilters As Integer
    Public StockFilterBy As String
    Public StockFilterByWhat As String
    Public StockByDate As String
    Public StockSortBy As String

    'Activity
    Public ListOfActivityId As New List(Of Integer)
    Public ListOfActivityName As New List(Of String)
    Public ListOfActionBy As New List(Of Integer)
    Public ListOfManagement As New List(Of String)
    Public ListOfActivityDate As New List(Of String)
    Public ListOfActivityTime As New List(Of String)
    Public listofActivityDetails As New List(Of String)

    Public ActivityNumberOfFilters As Integer
    Public ActivityFilterBy As String
    Public ActivityByDate As String
    Public ActivitySortBy As String

    'Inventory Transaction
    Public ListOfTransactionId As New List(Of Integer)
    Public ListOfTransactionStockId As New List(Of Integer)
    Public ListOfTransactionName As New List(Of String)
    Public ListOfTransactionQuantity As New List(Of Integer)
    Public ListOfTransactionDate As New List(Of String)
    Public ListOfTransactionTime As New List(Of String)
    Public ListOfTransactionActionBy As New List(Of Integer)

    Public SearchTransactionId As New List(Of Integer)
    Public SearchTransactionStockId As New List(Of Integer)
    Public SearchTransactionType As New List(Of String)

    Public TransactionNumberOfFilters As Integer
    Public TransactionFilterBy As String
    Public TransactionByDate As String
    Public TransactionSortBy As String

    
    'Sales
    Public ListOfSaleId As New List(Of Integer)
    Public ListOfSaleStockId As New List(Of Integer)
    Public ListOfQuantitySold As New List(Of Integer)
    Public ListOfItemPrice As New List(Of Double)
    Public ListOfExpenses As New List(Of Double)
    Public ListOfGrossSale As New List(Of Double)
    Public ListOfNetSale As New List(Of Double)
    Public ListOfSaleDate As New List(Of String)
    Public listofSaleTime As New List(Of String)

    Public SaleNumberOfFilters As Integer
    Public SaleFilterBy As String
    Public SaleByDate As String
    Public SaleSortBy As String

    Public SearchBySaleId As New List(Of Integer)
    Public SearchBySaleStockId As New List(Of Integer)
    Public SearchBySaleQuantity As New List(Of Integer)
    Public SearchByGrossSale As New List(Of Double)

    'Inventory Valuation
    Public ListofInventoryValuationId As New List(Of Integer)
    Public ListofInventoryValuationStockId As New List(Of Integer)
    Public ListofInventoryValuationRetail As New List(Of Double)
    Public ListofInventoryValuationWholesale As New List(Of Double)
    Public ListofInventoryValuationExpiration As New List(Of Double)
    Public ListofInventoryValuationDateAdded As New List(Of String)
    Public ListofInventoryValuationTimeAdded As New List(Of String)
    Public ListofInventoryValuationAdded As New List(Of Boolean)

    Public ListofExpiredStockId As New List(Of Integer)

    Public ValuationNumberOfFilters As Integer
    Public ValuationFilterBy As String
    Public ValuationByDate As String
    Public ValuationSortBy As String

    Public SearchByValuationId As New List(Of Integer)
    Public SearchByValuationStockId As New List(Of Integer)
    Public SearchByRetailValuation As New List(Of Double)
    Public SearchByExpirationValuation As New List(Of Double)

    'Database Backup
    Public ListOfBackupId As New List(Of Integer)
    Public ListOfBackUpName As New List(Of String)
    Public ListOfDirectory As New List(Of String)
    Public ListOfDateAdded As New List(Of String)
    Public ListOfTimeAdded As New List(Of String)
    Public ListOfDatabaseAddedBy As New List(Of Integer)

    Public BackUpNumberOfFilters As Integer
    Public BackUpFilterBy As String
    Public BackUpByDate As String
    Public BackUpSortBy As String

    Public SearchByBackUpId As New List(Of Integer)
    Public SearchByBackUpName As New List(Of String)



End Module
