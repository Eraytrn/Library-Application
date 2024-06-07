using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ce103_hw3_library_lib
{
    internal class Book
    {

        #region Public Constants
        public const int ID_LENGTH = 4;


        public const int STATUS_LENGTH = 100;

        public const int YEAR_LENGHT = 30;

        public const int PAGES_LENGHT = 30;

        public const int ABSTRACT_LENGHT = 30;

        public const int CITY_LENGHT = 30;

        public const int EDITION_LENGHT = 30;

        public const int PUBLISHER_LENGHT = 30;

        public const int CATALOGID_LENGHT = 30;

        public const int PRICE_LENGHT = 30;

        public const int RACKNO_LENGHT = 30;

        public const int ROWNO_LENGHT = 30;

        public const int RETURN_LENGHT = 100;

        public const int GIVEN_LENGHT = 100;

        public const int URL_LENGHT = 100;

        public const int TAGS_MAX_COUNT = 5;
        public const int TAGS_LENGHT = 20;

        public const int EDITORS_MAX_COUNT = 5;
        public const int EDITOR_NAME_MAX_LENGHT = 100;

        public const int TITLE_MAX_LENGTH = 100;

        public const int DESCRIPTION_MAX_LENGTH = 300;

        public const int AUTHORS_MAX_COUNT = 5;
        public const int AUTHORS_NAME_MAX_LENGTH = 100;

        public const int CATEGORY_MAX_COUNT = 5;
        public const int CATEGORY_NAME_MAX_LENGTH = 100;

        public const int BOOK_DATA_BLOCK_SIZE = ID_LENGTH +
                                                YEAR_LENGHT +
                                                PAGES_LENGHT +
                                                ABSTRACT_LENGHT +

                                                CITY_LENGHT +
                                                EDITION_LENGHT +
                                                PUBLISHER_LENGHT +
                                                CATALOGID_LENGHT +
                                                PRICE_LENGHT +
                                                RACKNO_LENGHT +
                                                ROWNO_LENGHT +
                                                RETURN_LENGHT +
                                                GIVEN_LENGHT +
                                                URL_LENGHT +
                                                (TAGS_MAX_COUNT * TAGS_LENGHT) +
                                                (EDITORS_MAX_COUNT * EDITOR_NAME_MAX_LENGHT) +
                                                TITLE_MAX_LENGTH +
                                                DESCRIPTION_MAX_LENGTH +
                                                (AUTHORS_MAX_COUNT * AUTHORS_NAME_MAX_LENGTH) +
                                                STATUS_LENGTH +
                                                (CATEGORY_MAX_COUNT * CATEGORY_NAME_MAX_LENGTH);
        #endregion

        #region Private Fields

        private int _id;
        private string _title;
        private string _description;
        private List<string> _authors;
        private List<string> _categories;
        private List<string> _editors;
        private List<string> _tags;
        private string _status;
        private string _year;
        private string _pages;
        private string _abstract;
        private string _city;
        private string _edition;
        private string _publisher;
        private string _catalogid;
        private string _price;
        private string _rackno;
        private string _rowno;
        private string _return;
        private string _given;
        private string _url;




        #endregion

        #region Public Properties
        public int Id { get { return _id; } set { _id = value; } }

        public string Title { get { return _title; } set { _title = value; } }
        public string Status { get { return _status; } set { _status = value; } }
        public string Description { get { return _description; } set { _description = value; } }
        public List<string> Authors { get { return _authors; } set { _authors = value; } }
        public List<string> Categories { get { return _categories; } set { _categories = value; } }
        public List<string> Editors { get { return _editors; } set { _editors = value; } }
        public List<string> Tags { get { return _tags; } set { _tags = value; } }
        public string Year { get { return _year; } set { _year = value; } }
        public string Abstract { get { return _abstract; } set { _abstract = value; } }
        public string City { get { return _city; } set { _city = value; } }
        public string Edition { get { return _edition; } set { _edition = value; } }
        public string Publisher { get { return _publisher; } set { _publisher = value; } }
        public string Return { get { return _return; } set { _return = value; } }
        public string Given { get { return _given; } set { _given = value; } }
        public string Url { get { return _url; } set { _url = value; } }
        public string Pages { get { return _pages; } set { _pages = value; } }
        public string CatalogId { get { return _catalogid; } set { _catalogid = value; } }
        public string Price { get { return _price; } set { _price = value; } }
        public string RackNo { get { return _rackno; } set { _rackno = value; } }
        public string RowNo { get { return _rowno; } set { _rowno = value; } }


        #endregion

        #region Constructors
        public Book()
        {
            _authors = new List<string>();
            _editors = new List<string>();
            _categories = new List<string>();
            _tags = new List<string>();
        }
        #endregion

        #region Utility Methods
        public static byte[] BookToByteArrayBlock(Book book)
        {
            int index = 0;

            byte[] dataBuffer = new byte[BOOK_DATA_BLOCK_SIZE];

            #region copy book id
            byte[] idBytes = ConversionUtility.IntegerToByteArray(book.Id);
            Array.Copy(idBytes, 0, dataBuffer, index, idBytes.Length);
            index += Book.ID_LENGTH;
            #endregion




            #region copy book CatalogId
            byte[] catalogidBytes = ConversionUtility.StringToByteArray(book.CatalogId);
            Array.Copy(catalogidBytes, 0, dataBuffer, index, catalogidBytes.Length);
            index += Book.CATALOGID_LENGHT;
            #endregion

            #region copy book Pages
            byte[] pagebytes = ConversionUtility.StringToByteArray(book.Pages);
            Array.Copy(pagebytes, 0, dataBuffer, index, pagebytes.Length);
            index += Book.PAGES_LENGHT;
            #endregion

            #region copy book Price
            byte[] pricebytes = ConversionUtility.StringToByteArray(book.Price);
            Array.Copy(pricebytes, 0, dataBuffer, index, pricebytes.Length);
            index += Book.PRICE_LENGHT;
            #endregion

            #region copy book RackNo
            byte[] racnkobytes = ConversionUtility.StringToByteArray(book.RackNo);
            Array.Copy(racnkobytes, 0, dataBuffer, index, racnkobytes.Length);
            index += Book.RACKNO_LENGHT;
            #endregion

            #region copy book RowNo
            byte[] rownobytes = ConversionUtility.StringToByteArray(book.RowNo);
            Array.Copy(rownobytes, 0, dataBuffer, index, rownobytes.Length);
            index += Book.ROWNO_LENGHT;
            #endregion

            #region copy book title
            byte[] titleBytes = ConversionUtility.StringToByteArray(book.Title);
            Array.Copy(titleBytes, 0, dataBuffer, index, titleBytes.Length);
            index += Book.TITLE_MAX_LENGTH;
            #endregion

            #region copy book Year
            byte[] yearbytes = ConversionUtility.StringToByteArray(book.Year);
            Array.Copy(yearbytes, 0, dataBuffer, index, yearbytes.Length);
            index += Book.YEAR_LENGHT;
            #endregion

            #region copy book Abstract
            byte[] abstractBytes = ConversionUtility.StringToByteArray(book.Abstract);
            Array.Copy(abstractBytes, 0, dataBuffer, index, abstractBytes.Length);
            index += Book.ABSTRACT_LENGHT;
            #endregion

            #region copy book City
            byte[] cityBytes = ConversionUtility.StringToByteArray(book.City);
            Array.Copy(cityBytes, 0, dataBuffer, index, cityBytes.Length);
            index += Book.CITY_LENGHT;
            #endregion

            #region copy book Edition
            byte[] editionBytes = ConversionUtility.StringToByteArray(book.Edition);
            Array.Copy(editionBytes, 0, dataBuffer, index, editionBytes.Length);
            index += Book.EDITION_LENGHT;
            #endregion

            #region copy book Publisher
            byte[] publisherBytes = ConversionUtility.StringToByteArray(book.Publisher);
            Array.Copy(publisherBytes, 0, dataBuffer, index, publisherBytes.Length);
            index += Book.PUBLISHER_LENGHT;
            #endregion

            #region copy book Return
            byte[] returnBytes = ConversionUtility.StringToByteArray(book.Return);
            Array.Copy(returnBytes, 0, dataBuffer, index, returnBytes.Length);
            index += Book.RETURN_LENGHT;
            #endregion

            #region copy book Given
            byte[] givenbytes = ConversionUtility.StringToByteArray(book.Given);
            Array.Copy(givenbytes, 0, dataBuffer, index, givenbytes.Length);
            index += Book.GIVEN_LENGHT;
            #endregion

            #region copy book Url
            byte[] urlBytes = ConversionUtility.StringToByteArray(book.Url);
            Array.Copy(urlBytes, 0, dataBuffer, index, urlBytes.Length);
            index += Book.URL_LENGHT;
            #endregion

            #region copy book status
            byte[] statusBytes = ConversionUtility.StringToByteArray(book.Status);
            Array.Copy(statusBytes, 0, dataBuffer, index, statusBytes.Length);
            index += Book.STATUS_LENGTH;
            #endregion

            #region copy book description
            byte[] descBytes = ConversionUtility.StringToByteArray(book.Description);
            Array.Copy(descBytes, 0, dataBuffer, index, descBytes.Length);
            index += Book.DESCRIPTION_MAX_LENGTH;
            #endregion

            #region copy book authors
            byte[] authorBytes = ConversionUtility.StringListToByteArray(book.Authors,
                                                                            Book.AUTHORS_MAX_COUNT,
                                                                            Book.AUTHORS_NAME_MAX_LENGTH);
            Array.Copy(authorBytes, 0, dataBuffer, index, authorBytes.Length);
            index += authorBytes.Length; //Here we can use also Book.AUTHORS_MAX_COUNT * Book.AUTHORS_NAME_MAX_LENGTH
            #endregion

            #region copy book categories
            byte[] categoryBytes = ConversionUtility.StringListToByteArray(book.Categories,
                                                                            Book.CATEGORY_MAX_COUNT,
                                                                            Book.CATEGORY_NAME_MAX_LENGTH);
            Array.Copy(categoryBytes, 0, dataBuffer, index, categoryBytes.Length);
            index += categoryBytes.Length; //Here we can use also Book.CATEGORY_MAX_COUNT * Book.CATEGORY_NAME_MAX_LENGTH
            #endregion

            #region copy book Tags
            byte[] tagsbytes = ConversionUtility.StringListToByteArray(book.Tags,
                                                                            Book.TAGS_MAX_COUNT,
                                                                            Book.TAGS_LENGHT);
            Array.Copy(tagsbytes, 0, dataBuffer, index, tagsbytes.Length);
            index += tagsbytes.Length;
            #endregion

            #region copy book Editors
            byte[] editorsbytes = ConversionUtility.StringListToByteArray(book.Editors,
                                                                            Book.EDITORS_MAX_COUNT,
                                                                            Book.EDITOR_NAME_MAX_LENGHT);
            Array.Copy(editorsbytes, 0, dataBuffer, index, editorsbytes.Length);
            index += editorsbytes.Length;
            #endregion


            if (index != dataBuffer.Length)
            {
                throw new ArgumentException("Index and DataBuffer Size Not Matched");
            }

            return dataBuffer;
        }

        public static Book ByteArrayBlockToBook(byte[] byteArray)
        {

            Book book = new Book();

            if (byteArray.Length != BOOK_DATA_BLOCK_SIZE)
            {
                throw new ArgumentException("Byte Array Size Not Match with Constant Data Block Size");
            }

            int index = 0;

            //byte[] dataBuffer = new byte[BOOK_DATA_BLOCK_SIZE];

            #region copy book id
            byte[] idBytes = new byte[Book.ID_LENGTH];
            Array.Copy(byteArray, index, idBytes, 0, idBytes.Length);
            book.Id = ConversionUtility.ByteArrayToInteger(idBytes);

            index += Book.ID_LENGTH;
            #endregion



            #region copy book Pages
            byte[] pagesBytes = new byte[Book.PAGES_LENGHT];
            Array.Copy(byteArray, index, pagesBytes, 0, pagesBytes.Length);
            book.Pages = ConversionUtility.ByteArrayToString(pagesBytes);

            index += Book.PAGES_LENGHT;
            #endregion

            #region copy book CatalogId
            byte[] catalogbidBytes = new byte[Book.CATALOGID_LENGHT];
            Array.Copy(byteArray, index, catalogbidBytes, 0, catalogbidBytes.Length);
            book.CatalogId = ConversionUtility.ByteArrayToString(catalogbidBytes);

            index += Book.CATALOGID_LENGHT;
            #endregion

            #region copy book Price
            byte[] priceBytes = new byte[Book.PRICE_LENGHT];
            Array.Copy(byteArray, index, priceBytes, 0, priceBytes.Length);
            book.Price = ConversionUtility.ByteArrayToString(priceBytes);

            index += Book.PRICE_LENGHT;
            #endregion

            #region copy book RackNo
            byte[] racknoBytes = new byte[Book.RACKNO_LENGHT];
            Array.Copy(byteArray, index, racknoBytes, 0, racknoBytes.Length);
            book.RackNo = ConversionUtility.ByteArrayToString(racknoBytes);

            index += Book.RACKNO_LENGHT;
            #endregion

            #region copy book RowNo
            byte[] rownobytes = new byte[Book.ROWNO_LENGHT];
            Array.Copy(byteArray, index, rownobytes, 0, rownobytes.Length);
            book.RowNo = ConversionUtility.ByteArrayToString(rownobytes);

            index += Book.ROWNO_LENGHT;
            #endregion

            #region copy book title
            byte[] titleBytes = new byte[Book.TITLE_MAX_LENGTH];
            Array.Copy(byteArray, index, titleBytes, 0, titleBytes.Length);
            book.Title = ConversionUtility.ByteArrayToString(titleBytes);

            index += Book.TITLE_MAX_LENGTH;
            #endregion

            #region copy book Year
            byte[] yearbytes = new byte[Book.YEAR_LENGHT];
            Array.Copy(byteArray, index, yearbytes, 0, yearbytes.Length);
            book.Year = ConversionUtility.ByteArrayToString(yearbytes);

            index += Book.YEAR_LENGHT;
            #endregion

            #region copy book Abstract
            byte[] abstractbytes = new byte[Book.ABSTRACT_LENGHT];
            Array.Copy(byteArray, index, abstractbytes, 0, abstractbytes.Length);
            book.Abstract = ConversionUtility.ByteArrayToString(abstractbytes);

            index += Book.ABSTRACT_LENGHT;
            #endregion

            #region copy book City
            byte[] citybytes = new byte[Book.CITY_LENGHT];
            Array.Copy(byteArray, index, citybytes, 0, citybytes.Length);
            book.City = ConversionUtility.ByteArrayToString(citybytes);

            index += Book.CITY_LENGHT;
            #endregion

            #region copy book Edition
            byte[] editionbytes = new byte[Book.CITY_LENGHT];
            Array.Copy(byteArray, index, editionbytes, 0, editionbytes.Length);
            book.Edition = ConversionUtility.ByteArrayToString(editionbytes);

            index += Book.EDITION_LENGHT;
            #endregion

            #region copy book Publisher
            byte[] publisherbytes = new byte[Book.PUBLISHER_LENGHT];
            Array.Copy(byteArray, index, publisherbytes, 0, publisherbytes.Length);
            book.Publisher = ConversionUtility.ByteArrayToString(publisherbytes);

            index += Book.PUBLISHER_LENGHT;
            #endregion

            #region copy book Return
            byte[] returnbytes = new byte[Book.RETURN_LENGHT];
            Array.Copy(byteArray, index, returnbytes, 0, returnbytes.Length);
            book.Return = ConversionUtility.ByteArrayToString(returnbytes);

            index += Book.RETURN_LENGHT;
            #endregion

            #region copy book Given
            byte[] givenbytes = new byte[Book.GIVEN_LENGHT];
            Array.Copy(byteArray, index, givenbytes, 0, givenbytes.Length);
            book.Given = ConversionUtility.ByteArrayToString(givenbytes);

            index += Book.GIVEN_LENGHT;
            #endregion

            #region copy book url
            byte[] urlbytes = new byte[Book.URL_LENGHT];
            Array.Copy(byteArray, index, urlbytes, 0, urlbytes.Length);
            book.Url = ConversionUtility.ByteArrayToString(urlbytes);

            index += Book.URL_LENGHT;
            #endregion


            #region copy book status
            byte[] statusBytes = new byte[Book.STATUS_LENGTH];
            Array.Copy(byteArray, index, statusBytes, 0, statusBytes.Length);
            book.Status = ConversionUtility.ByteArrayToString(statusBytes);

            index += Book.STATUS_LENGTH;
            #endregion

            #region copy book description
            byte[] descBytes = new byte[Book.DESCRIPTION_MAX_LENGTH];
            Array.Copy(byteArray, index, descBytes, 0, descBytes.Length);
            book.Description = ConversionUtility.ByteArrayToString(descBytes);

            index += Book.DESCRIPTION_MAX_LENGTH;
            #endregion

            #region copy book authors

            byte[] authorBytes = new byte[Book.AUTHORS_MAX_COUNT * Book.AUTHORS_NAME_MAX_LENGTH];

            Array.Copy(byteArray, index, authorBytes, 0, authorBytes.Length);

            book.Authors = ConversionUtility.ByteArrayToStringList(authorBytes,
                                                                            Book.AUTHORS_MAX_COUNT,
                                                                            Book.AUTHORS_NAME_MAX_LENGTH);

            index += authorBytes.Length;
            #endregion

            #region copy book categories
            byte[] categoryBytes = new byte[Book.CATEGORY_MAX_COUNT * Book.CATEGORY_NAME_MAX_LENGTH];

            Array.Copy(byteArray, index, categoryBytes, 0, categoryBytes.Length);

            book.Categories = ConversionUtility.ByteArrayToStringList(categoryBytes,
                                                                            Book.CATEGORY_MAX_COUNT,
                                                                            Book.CATEGORY_NAME_MAX_LENGTH);

            index += categoryBytes.Length;
            #endregion

            #region copy book Tags
            byte[] tagsbytes = new byte[Book.TAGS_MAX_COUNT * Book.TAGS_LENGHT];

            Array.Copy(byteArray, index, tagsbytes, 0, tagsbytes.Length);

            book.Tags = ConversionUtility.ByteArrayToStringList(tagsbytes,
                                                                            Book.TAGS_MAX_COUNT,
                                                                            Book.TAGS_LENGHT);

            index += tagsbytes.Length;
            #endregion

            #region copy book Editor
            byte[] editorbytes = new byte[Book.EDITORS_MAX_COUNT * Book.EDITOR_NAME_MAX_LENGHT];

            Array.Copy(byteArray, index, editorbytes, 0, editorbytes.Length);

            book.Editors = ConversionUtility.ByteArrayToStringList(editorbytes,
                                                                            Book.EDITORS_MAX_COUNT,
                                                                            Book.EDITOR_NAME_MAX_LENGHT);

            index += editorbytes.Length;
            #endregion




            if (index != byteArray.Length)
            {
                throw new ArgumentException("Index and DataBuffer Size Not Matched");
            }

            if (book.Id == 0)
            {
                return null;
            }
            else
            {
                return book;
            }

        }
        #endregion

    }
}
