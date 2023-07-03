# The class provides the following methods:
1. Index: Sets the index name to be used in subsequent operations. It takes a string as an argument and returns the instance of the Elasticsearch class.
2. CreateIndexIfNotExists: Creates the specified index if it doesn't already exist. It takes a string as an argument, representing the index name.
3. AddOrUpdateBulk: Adds or updates a list of documents in bulk. It takes IEnumerable a generic type T where T is the type of document. The method returns a boolean indicating whether the operation was successful.
4. AddOrUpdate: Adds or updates a single document. It takes a single document of generic type T as an argument. The method returns a boolean indicating whether the operation was successful.
5. Get: Retrieves a document by its key. It takes a string as an argument, representing the key, and returns the document of generic type T.
6. GetAll: Retrieves all documents of type T. It returns a list of documents of a generic type T or default if the operation was unsuccessful.
7. Query: Executes a query using the provided QueryContainer predicate and returns a list of matching documents of a generic type T or default if the operation was unsuccessful.
8. Remove: Removes a document by its key. It takes a string as an argument, representing the key, and returns a boolean indicating whether the operation was successful.
9. RemoveAll: Removes all documents of type T. It returns the number of deleted documents.