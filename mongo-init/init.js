// Set the database name
db = db.getSiblingDB('MarsIdentity');

db.createCollection('Category');

// Insert the category data
db.Category.insertMany([
    {
        "_id": ObjectId("5c62184640176bdbbbac98a5"),
        "Value": "1",
        "Name": "Software Development",
        "Subcategory": [
            {
                "Value": "1",
                "Name": "Solution Architecture Design",
                "IsDeleted": false
            },
            {
                "Value": "2",
                "Name": "Programming",
                "IsDeleted": false
            },
            {
                "Value": "3",
                "Name": "Front End Development",
                "IsDeleted": false
            },
            {
                "Value": "4",
                "Name": "Back End Development",
                "IsDeleted": false
            },
            {
                "Value": "5",
                "Name": "Design Pattern",
                "IsDeleted": false
            },
            {
                "Value": "6",
                "Name": "DevOps CI/CD",
                "IsDeleted": false
            },
            {
                "Value": "7",
                "Name": "Other",
                "IsDeleted": false
            }
        ],
        "IsDeleted": false
    },
    {
        "_id": ObjectId("5c62184640176bdbbbac98a6"),
        "Value": "2",
        "Name": "Data Analysis & Business Intelligence",
        "Subcategory": [
            {
                "Value": "1",
                "Name": "Data Cleaning and Standardisation",
                "IsDeleted": false
            },
            {
                "Value": "2",
                "Name": "Data Warehousing",
                "IsDeleted": false
            },
            {
                "Value": "3",
                "Name": "ETL Design",
                "IsDeleted": false
            },
            {
                "Value": "4",
                "Name": "Data Visualisation",
                "IsDeleted": false
            },
            {
                "Value": "5",
                "Name": "PowerBI",
                "IsDeleted": false
            },
            {
                "Value": "6",
                "Name": "Tableau",
                "IsDeleted": false
            },
            {
                "Value": "7",
                "Name": "Wherescape RED",
                "IsDeleted": false
            },
            {
                "Value": "8",
                "Name": "Other",
                "IsDeleted": false
            }
        ],
        "IsDeleted": false
    },
    {
        "_id": ObjectId("5c62184640176bdbbbac98a7"),
        "Value": "3",
        "Name": "Test Automation",
        "Subcategory": [
            {
                "Value": "1",
                "Name": "Selenium",
                "IsDeleted": false
            },
            {
                "Value": "2",
                "Name": "Cucumber/Specflow",
                "IsDeleted": false
            },
            {
                "Value": "3",
                "Name": "API Testing",
                "IsDeleted": false
            },
            {
                "Value": "4",
                "Name": "Performance Testing",
                "IsDeleted": false
            },
            {
                "Value": "5",
                "Name": "Other",
                "IsDeleted": false
            }
        ],
        "IsDeleted": false
    },
    {
        "_id": ObjectId("5c62184640176bdbbbac98a8"),
        "Value": "4",
        "Name": "Data Science",
        "Subcategory": [
            {
                "Value": "1",
                "Name": "Python Programming",
                "IsDeleted": false
            },
            {
                "Value": "2",
                "Name": "R Studio Programming",
                "IsDeleted": false
            },
            {
                "Value": "3",
                "Name": "Big Data",
                "IsDeleted": false
            },
            {
                "Value": "4",
                "Name": "Other",
                "IsDeleted": false
            }
        ],
        "IsDeleted": false
    },
    {
        "_id": ObjectId("5c62184640176bdbbbac98a9"),
        "Value": "5",
        "Name": "Machine Learning",
        "Subcategory": [
            {
                "Value": "1",
                "Name": "Supervised Learning",
                "IsDeleted": false
            },
            {
                "Value": "2",
                "Name": "Unsupervised Learning",
                "IsDeleted": false
            },
            {
                "Value": "3",
                "Name": "Reinforcement Learning",
                "IsDeleted": false
            },
            {
                "Value": "4",
                "Name": "Other",
                "IsDeleted": false
            }
        ],
        "IsDeleted": false
    },
    {
        "_id": ObjectId("5c62184640176bdbbbac98aa"),
        "Value": "6",
        "Name": "Game Development",
        "Subcategory": [
            {
                "Value": "1",
                "Name": "Unity",
                "IsDeleted": false
            },
            {
                "Value": "2",
                "Name": "Unreal",
                "IsDeleted": false
            },
            {
                "Value": "3",
                "Name": "3D Modeling",
                "IsDeleted": false
            },
            {
                "Value": "4",
                "Name": "Game Design",
                "IsDeleted": false
            },
            {
                "Value": "5",
                "Name": "HTML5",
                "IsDeleted": false
            },
            {
                "Value": "6",
                "Name": "Other",
                "IsDeleted": false
            }
        ],
        "IsDeleted": false
    },
    {
        "_id": ObjectId("5c62184640176bdbbbac98ab"),
        "Value": "7",
        "Name": "Communication",
        "Subcategory": [
            {
                "Value": "1",
                "Name": "Communication at Work",
                "IsDeleted": false
            },
            {
                "Value": "2",
                "Name": "Job Hunting Advice",
                "IsDeleted": false
            },
            {
                "Value": "3",
                "Name": "Job Market Advice",
                "IsDeleted": false
            },
            {
                "Value": "4",
                "Name": "Interview Advice",
                "IsDeleted": false
            },
            {
                "Value": "5",
                "Name": "Job Analysis Consulting",
                "IsDeleted": false
            },
            {
                "Value": "6",
                "Name": "Other",
                "IsDeleted": false
            }
        ],
        "IsDeleted": false
    },
    {
        "_id": ObjectId("5c62184640176bdbbbac98ac"),
        "Value": "8",
        "Name": "Fun & Lifestyle",
        "Subcategory": [
            {
                "Value": "1",
                "Name": "Online Lessons",
                "IsDeleted": false
            },
            {
                "Value": "2",
                "Name": "Relationship Advice",
                "IsDeleted": false
            },
            {
                "Value": "3",
                "Name": "Astrology",
                "IsDeleted": false
            },
            {
                "Value": "4",
                "Name": "Health, Nutrition & Fitness",
                "IsDeleted": false
            },
            {
                "Value": "5",
                "Name": "Gaming",
                "IsDeleted": false
            },
            {
                "Value": "6",
                "Name": "Other",
                "IsDeleted": false
            }
        ],
        "IsDeleted": false
    },
    {
        "_id": ObjectId("5c62184640176bdbbbac99ad"),
        "Value": "9",
        "Name": "Recruitment",
        "Subcategory": [
            {
                "Value": "1",
                "Name": "Employability",
                "IsDeleted": false
            },
            {
                "Value": "2",
                "Name": "CV Advices",
                "IsDeleted": false
            },
            {
                "Value": "3",
                "Name": "Interview Advice",
                "IsDeleted": false
            },
            {
                "Value": "4",
                "Name": "Job Market Insight",
                "IsDeleted": false
            }
        ],
        "IsDeleted": false
    }
]);

// Print a message to confirm the data was inserted
print('Category data initialization completed successfully');