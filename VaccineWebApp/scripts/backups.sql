INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'79cf333c-afcd-4c8b-9cf6-b6779b80f975', N'admin', N'admin', N'f38b2c0f-396d-4231-9a27-53bb2f11964b')
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'bb97e0d0-aff5-4606-acab-859eb829e88b', N'admins@vaccinewebapp.com', N'ADMINS@VACCINEWEBAPP.COM', N'admins@vaccinewebapp.com', N'ADMINS@VACCINEWEBAPP.COM', 1, N'AQAAAAEAACcQAAAAEIPmKRVcGExj0oaHPM8FX3WoLP4PCpIYnIGki91CVKi0KfnV2OS79pHN1UNw3j00Qg==', N'HWZOPF473Z6HJKURCBDRG44YKALCFKMM', N'955a6d1a-fcb5-4234-a330-63fe6e7b20dc', NULL, 0, 0, NULL, 1, 0)
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'd4f2f0f1-227e-4016-a6ec-874b6c82984f', N'edmund@gmail.com', N'EDMUND@GMAIL.COM', N'edmund@gmail.com', N'EDMUND@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAEJfI2pY3YxBQwGTQp0shSGW424Twu9PDKioyP9MYseZhj5DweC/gwbucdHXMdEK5fw==', N'QXGPMTAIIPYHEIK4HBM7ZCB3ZSQ2W4ZJ', N'7ea20a62-9b3a-456a-9ad6-d516886806be', NULL, 0, 0, NULL, 1, 0)
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'bb97e0d0-aff5-4606-acab-859eb829e88b', N'79cf333c-afcd-4c8b-9cf6-b6779b80f975')
GO
SET IDENTITY_INSERT [dbo].[Hospitals] ON 
GO
INSERT [dbo].[Hospitals] ([HospitalID], [Name], [Address], [ContactNo]) VALUES (1, N'Auckland City Hospital', N'2 Park Road, Grafton, Auckland 1023, New Zealand', N'+64 9-367 0000')
GO
INSERT [dbo].[Hospitals] ([HospitalID], [Name], [Address], [ContactNo]) VALUES (2, N'Southern Cross Hospital New Plymouth', N'205 Saint Aubyn Street, New Plymouth 4310, New Zealand', N'+64 6-759 4820')
GO
INSERT [dbo].[Hospitals] ([HospitalID], [Name], [Address], [ContactNo]) VALUES (3, N'Taranaki Base Hospital', N'David Street, Westown, New Plymouth 4310, New Zealand', N'+64 6-753 6139')
GO
INSERT [dbo].[Hospitals] ([HospitalID], [Name], [Address], [ContactNo]) VALUES (4, N'Nelson Hospital', N'7010 Franklyn Street, Nelson South, Nelson 7010, New Zealand', N'+64 3-546 1800')
GO
SET IDENTITY_INSERT [dbo].[Hospitals] OFF
GO
SET IDENTITY_INSERT [dbo].[Bookings] ON 
GO
INSERT [dbo].[Bookings] ([BookingID], [BookingDate], [UserID], [HospitalID]) VALUES (1, CAST(N'2021-05-18T21:10:00.0000000' AS DateTime2), N'edmund@gmail.com', 1)
GO
INSERT [dbo].[Bookings] ([BookingID], [BookingDate], [UserID], [HospitalID]) VALUES (3, CAST(N'2021-06-24T21:30:00.0000000' AS DateTime2), N'edmund@gmail.com', 1)
GO
SET IDENTITY_INSERT [dbo].[Bookings] OFF
GO
SET IDENTITY_INSERT [dbo].[Faqs] ON 
GO
INSERT [dbo].[Faqs] ([FaqID], [Question], [Answer]) VALUES (1, N'What is COVID-19?', N'COVID-19 is the disease caused by a new coronavirus called SARS-CoV-2.  WHO first learned of this new virus on 31 December 2019, following a report of a cluster of cases of ‘viral pneumonia’ in Wuhan, People’s Republic of China.')
GO
INSERT [dbo].[Faqs] ([FaqID], [Question], [Answer]) VALUES (2, N'What are the symptoms of COVID-19?', N'The most common symptoms of COVID-19 are Fever,Dry cough and Fatigue. <br>
Other symptoms that are less common and may affect some patients include: Loss of taste or smell,
Nasal congestion, Conjunctivitis (also known as red eyes) Sore throat, Headache, Muscle or joint pain, Different types of skin rash, Nausea or vomiting, Diarrhea, Chills or dizziness.<br>
Symptoms of severe COVID‐19 disease include: Shortness of breath, Loss of appetite, Confusion, Persistent pain or pressure in the chest, High temperature (above 38 °C).')
GO
INSERT [dbo].[Faqs] ([FaqID], [Question], [Answer]) VALUES (3, N'What about rapid tests?', N'Rapid antigen tests (sometimes known as a rapid diagnostic test – RDT) detect viral proteins (known as antigens). Samples are collected from the nose and/or throat with a swab. These tests are cheaper than PCR and will offer results more quickly, although they are generally less accurate. These tests perform best when there is more virus circulating in the community and when sampled from an individual during the time they are most infectious. ')
GO
INSERT [dbo].[Faqs] ([FaqID], [Question], [Answer]) VALUES (4, N'What test should I get to see if I have COVID-19?', N'In most situations, a molecular test is used to detect SARS-CoV-2 and confirm infection. Polymerase chain reaction (PCR) is the most commonly used molecular test. Samples are collected from the nose and/or throat with a swab. Molecular tests detect virus in the sample by amplifying viral genetic material to detectable levels. For this reason, a molecular test is used to confirm an active infection, usually within a few days of exposure and around the time that symptoms may begin. ')
GO
INSERT [dbo].[Faqs] ([FaqID], [Question], [Answer]) VALUES (5, N' What should I do if I have COVID-19 symptoms?', N'If you have any symptoms suggestive of COVID-19, call your health care provider or COVID-19 hotline for instructions and find out when and where to get a test, stay at home for 14 days away from others and monitor your health.

If you have shortness of breath or pain or pressure in the chest, seek medical attention at a health facility immediately. Call your health care provider or hotline in advance for direction to the right health facility.

If you live in an area with malaria or dengue fever, seek medical care if you have a fever.

If local guidance recommends visiting a medical centre for testing, assessment or isolation, wear a medical mask while travelling to and from the facility and during medical care. Also keep at least a 1-metre distance from other people and avoid touching surfaces with your hands.  This applies to adults and children.')
GO
SET IDENTITY_INSERT [dbo].[Faqs] OFF
GO
SET IDENTITY_INSERT [dbo].[PersonalDetails] ON 
GO
INSERT [dbo].[PersonalDetails] ([PersonalDetailID], [Name], [UserID], [Address], [ContactNo], [Extension]) VALUES (1, N'Edmund Hillary', N'edmund@gmail.com', N'31  Ponsonby Road Freemans Bay Auckland', N'(021) 2599-501', N'.png')
GO
SET IDENTITY_INSERT [dbo].[PersonalDetails] OFF
GO
