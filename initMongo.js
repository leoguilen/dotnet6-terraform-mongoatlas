// set the database
var db = db.getSiblingDB('CAR_RENT_STORE');

// create the collections
db.createCollection('CARS_CATALOG', {
    validator: {
        $jsonSchema: {
            bsonType: "object",
            required: [
                "MANUFACTURER_NAME",
                "CAR_UUID",
                "CAR_MAKE_NAME",
                "CAR_MODEL_NAME",
                "CAR_YEAR_NUMBER",
                "CAR_IMAGE_URL",
                "CREATED_AT",
                "CREATED_BY",
            ],
            properties: {
                MANUFACTURER_NAME: {
                    bsonType: "string",
                    description: "must be a string and is required"
                },
                CAR_UUID: {
                    bsonType: "string",
                    description: "must be a string and is required"
                },
                CAR_MAKE_NAME: {
                    bsonType: "string",
                    description: "must be a string and is required"
                },
                CAR_MODEL_NAME: {
                    bsonType: "string",
                    description: "must be a string and is required"
                },
                CAR_YEAR_NUMBER: {
                    bsonType: "int",
                    minimum: 1990,
                    maximum: 2050,
                    description: "must be an integer in [ 1900, 2050 ] and is required"
                },
                CAR_COLOR_NAME: {
                    enum: ["Black", "White", "Gray", "Blue", "Red", "Silver"],
                    description: "can only be one of the enum values and is required"
                },
                CAR_ADDITIONAL_DETAILS: {
                    bsonType: "array",
                    items: {
                        bsonType: "string",
                    }
                },
                CREATED_AT: {
                    bsonType: "date",
                    description: "must be a timestamp and is required"
                },
                CREATED_BY: {
                    bsonType: "string",
                    description: "must be a string and is required"
                }
            }
        }
    }
});

// insert the data
db.CARS_CATALOG.insertMany([
    {
        MANUFACTURER_NAME: "Toyota",
        CAR_UUID: "3364b59d-5919-4069-9912-78bab94e5bef",
        CAR_MAKE_NAME: "Corolla",
        CAR_MODEL_NAME: "Corolla ALTIS 2.0 16V CVT FLEX",
        CAR_YEAR_NUMBER: 2020,
        CAR_COLOR_NAME: "Black",
        CAR_ADDITIONAL_DETAILS: [
            "4-door",
            "ABS",
            "Automatic",
            "Air Conditioning",
            "Power Door Locks",
            "Power Mirrors",
        ],
        CAR_IMAGE_URL: "https://www.autoguide.com/blog/wp-content/gallery/2020-toyota-corolla-live-photos-2-25-2019/2020-Toyota-Corolla-Sedan-01.jpg",
        CREATED_AT: new Date(),
        CREATED_BY: "admin",
    },
    {
        MANUFACTURER_NAME: "Toyota",
        CAR_UUID: "deb99630-6f37-4486-b337-71e3b0101411",
        CAR_MAKE_NAME: "Etios",
        CAR_MODEL_NAME: "Etios Sedan X Plus 1.5",
        CAR_YEAR_NUMBER: 2020,
        CAR_COLOR_NAME: "Silver",
        CAR_ADDITIONAL_DETAILS: [
            "4-door",
            "ABS",
            "Automatic",
            "Air Conditioning",
            "Power Door Locks",
            "Power Mirrors",
            "Alarm",
        ],
        CAR_IMAGE_URL: "https://th.bing.com/th/id/OIP.5rDWCCbLKO-M0aF8RzI3RgHaE1?pid=ImgDet&rs=1",
        CREATED_AT: new Date(),
        CREATED_BY: "admin",
    },
    {
        MANUFACTURER_NAME: "Toyota",
        CAR_UUID: "ac9e45aa-7a67-424a-a2a9-5b8a0f249388",
        CAR_MAKE_NAME: "Corolla",
        CAR_MODEL_NAME: "Corolla Gli Upper 1.8",
        CAR_YEAR_NUMBER: 2019,
        CAR_COLOR_NAME: "White",
        CAR_ADDITIONAL_DETAILS: [
            "4-door",
            "ABS",
            "Automatic",
            "Air Conditioning",
            "Power Door Locks",
            "Power Mirrors",
            "Alarm",
        ],
        CAR_IMAGE_URL: "https://th.bing.com/th/id/R.d67f19af87bbc8044250449349ea32fd?rik=7g28DfFj6JGiVw&pid=ImgRaw&r=0",
        CREATED_AT: new Date(),
        CREATED_BY: "admin",
    },
    {
        MANUFACTURER_NAME: "Honda",
        CAR_UUID: "2e42dac7-0f57-4254-9b61-700ffa40d586",
        CAR_MAKE_NAME: "Hr-v",
        CAR_MODEL_NAME: "Hr-v Ex 1.8",
        CAR_YEAR_NUMBER: 2018,
        CAR_COLOR_NAME: "Gray",
        CAR_ADDITIONAL_DETAILS: [
            "4-door",
            "ABS",
            "Automatic",
            "Air Conditioning",
            "Power Door Locks",
            "Power Mirrors",
            "Alarm",
        ],
        CAR_IMAGE_URL: "https://drngjg9hn4yur.cloudfront.net/181508/1024x768/58bd63f6674fbd08ecb21c68a6edb35c.jpg",
        CREATED_AT: new Date(),
        CREATED_BY: "admin",
    },
    {
        MANUFACTURER_NAME: "Honda",
        CAR_UUID: "56b13380-bc0a-4f3d-a075-953aaa0edaec",
        CAR_MAKE_NAME: "Accord",
        CAR_MODEL_NAME: "Accord Touring 2.0",
        CAR_YEAR_NUMBER: 2019,
        CAR_COLOR_NAME: "Black",
        CAR_ADDITIONAL_DETAILS: [
            "4-door",
            "ABS",
            "Automatic",
            "Air Conditioning",
            "Power Door Locks",
            "Power Mirrors",
            "Alarm",
        ],
        CAR_IMAGE_URL: "https://th.bing.com/th/id/R.122bafddb7af970c754da3080df6f343?rik=JjApnuRAmh9Rlg&riu=http%3a%2f%2fwww.sure2car.com%2fwp-content%2fuploads%2f2018%2f01%2f2018-Honda-Accord-2.0-Turbo-Touring-Rear-01.jpg&ehk=ANvp083rKf6GFp8ZW1aR5QX%2bt3ydjzbpthXKruEQpVs%3d&risl=&pid=ImgRaw&r=0",
        CREATED_AT: new Date(),
        CREATED_BY: "admin",
    },
    {
        MANUFACTURER_NAME: "Honda",
        CAR_UUID: "56b13380-bc0a-4f3d-a075-953aaa0edaec",
        CAR_MAKE_NAME: "Civic",
        CAR_MODEL_NAME: "Civic 1.5 TURBO TOURING",
        CAR_YEAR_NUMBER: 2019,
        CAR_COLOR_NAME: "Black",
        CAR_ADDITIONAL_DETAILS: [
            "4-door",
            "ABS",
            "Automatic",
            "Air Conditioning",
            "Power Door Locks",
            "Power Mirrors",
            "Alarm",
        ],
        CAR_IMAGE_URL: "https://th.bing.com/th/id/OIP.Nx-nPX2so4Xwn063ePMXxQHaE7?pid=ImgDet&rs=1",
        CREATED_AT: new Date(),
        CREATED_BY: "admin",
    },
    {
        MANUFACTURER_NAME: "Chevrolet",
        CAR_UUID: "2cd22092-6587-45e7-b1ad-5040aa32fcac",
        CAR_MAKE_NAME: "Onix",
        CAR_MODEL_NAME: "Onix 1.0 MPFI",
        CAR_YEAR_NUMBER: 2015,
        CAR_COLOR_NAME: "White",
        CAR_ADDITIONAL_DETAILS: [
            "4-door",
            "ABS",
            "Automatic",
            "Air Conditioning",
            "Power Mirrors",
            "Alarm",
        ],
        CAR_IMAGE_URL: "https://th.bing.com/th/id/OIP.EdZm5BSgttClTPHxqBMCngHaFj?pid=ImgDet&rs=1",
        CREATED_AT: new Date(),
        CREATED_BY: "admin",
    },
    {
        MANUFACTURER_NAME: "Chevrolet",
        CAR_UUID: "e9a62dc9-7f98-49f0-8e29-6e257e59d0ae",
        CAR_MAKE_NAME: "S10",
        CAR_MODEL_NAME: "S10 2.8 16V TURBO",
        CAR_YEAR_NUMBER: 2022,
        CAR_COLOR_NAME: "Silver",
        CAR_ADDITIONAL_DETAILS: [
            "4-door",
            "ABS",
            "Automatic",
            "Air Conditioning",
            "Power Door Locks",
            "Power Mirrors",
            "Alarm",
        ],
        CAR_IMAGE_URL: "https://www.automaistv.com.br/wp-content/uploads/2021/04/Chevrolet-S10-High-Country-2022-8_edited-990x556.jpg",
        CREATED_AT: new Date(),
        CREATED_BY: "admin",
    },
    {
        MANUFACTURER_NAME: "Chevrolet",
        CAR_UUID: "708c9b5e-6bc4-4236-8cfe-dbed1814bc15",
        CAR_MAKE_NAME: "Cruze",
        CAR_MODEL_NAME: "Cruze 1.4 TURBO LT",
        CAR_YEAR_NUMBER: 2019,
        CAR_COLOR_NAME: "Black",
        CAR_ADDITIONAL_DETAILS: [
            "4-door",
            "ABS",
            "Automatic",
            "Air Conditioning",
            "Power Door Locks",
            "Power Mirrors",
            "Alarm",
        ],
        CAR_IMAGE_URL: "https://s3.amazonaws.com/adset.images/0e6de7ad-6fc1-4089-ba06-9bf30790622420200810110056.jpeg",
        CREATED_AT: new Date(),
        CREATED_BY: "admin",
    },
    {
        MANUFACTURER_NAME: "Renault",
        CAR_UUID: "3f21eb90-7345-485c-88e5-ea019b8278df",
        CAR_MAKE_NAME: "Duster Oroch",
        CAR_MODEL_NAME: "Duster Oroch 2.0 16V",
        CAR_YEAR_NUMBER: 2019,
        CAR_COLOR_NAME: "White",
        CAR_ADDITIONAL_DETAILS: [
            "4-door",
            "ABS",
            "Automatic",
            "Air Conditioning",
            "Power Mirrors",
            "Alarm",
        ],
        CAR_IMAGE_URL: "https://th.bing.com/th/id/OIP.QFITv9g0FfInBZuMTCISOgHaEK?pid=ImgDet&rs=1",
        CREATED_AT: new Date(),
        CREATED_BY: "admin",
    },
    {
        MANUFACTURER_NAME: "Renault",
        CAR_UUID: "127cd8c5-097b-4fb8-844a-67241347d018",
        CAR_MAKE_NAME: "S10",
        CAR_MODEL_NAME: "S10 2.8 16V TURBO",
        CAR_YEAR_NUMBER: 2022,
        CAR_COLOR_NAME: "Silver",
        CAR_ADDITIONAL_DETAILS: [
            "4-door",
            "ABS",
            "Automatic",
            "Air Conditioning",
            "Power Door Locks",
            "Power Mirrors",
            "Alarm",
        ],
        CAR_IMAGE_URL: "https://www.automaistv.com.br/wp-content/uploads/2021/04/Chevrolet-S10-High-Country-2022-8_edited-990x556.jpg",
        CREATED_AT: new Date(),
        CREATED_BY: "admin",
    },
    {
        MANUFACTURER_NAME: "Renault",
        CAR_UUID: "5a1ee07e-c5df-4407-ae02-47d28b967cf1",
        CAR_MAKE_NAME: "KWID",
        CAR_MODEL_NAME: "KWID 1.0 12V SCE",
        CAR_YEAR_NUMBER: 2020,
        CAR_COLOR_NAME: "Blue",
        CAR_ADDITIONAL_DETAILS: [
            "4-door",
            "ABS",
            "Automatic",
            "Air Conditioning",
            "Power Door Locks",
            "Power Mirrors",
            "Alarm",
        ],
        CAR_IMAGE_URL: "https://www.autocerto.com/fotos/721/249234/10.jpg",
        CREATED_AT: new Date(),
        CREATED_BY: "admin",
    }
]);