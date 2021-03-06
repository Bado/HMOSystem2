USE [dsnlHMODB]
GO
/****** Object:  Table [dbo].[ACCODE]    Script Date: 5/13/2016 6:00:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ACCODE](
	[ACCODE] [varchar](10) NOT NULL,
	[DESCRIPTN] [varchar](70) NULL,
	[ACTYPE] [varchar](1) NULL,
	[POST_AC] [varchar](10) NULL,
	[ACLEVEL] [varchar](1) NULL,
	[ACACTIVE] [varchar](1) NULL,
	[CONSOLID] [varchar](10) NULL,
	[OPENBAL] [numeric](17, 3) NULL,
	[ctype2] [char](15) NULL,
	[acctbalcat] [varchar](1) NULL,
	[Runingbalance] [numeric](17, 3) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ACCTPERIOD]    Script Date: 5/13/2016 6:00:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ACCTPERIOD](
	[ACPERIOD] [char](2) NOT NULL,
	[ACYEAR] [char](4) NOT NULL,
	[OPENDATE] [date] NULL,
	[CLOSEDATE] [date] NULL,
	[CLOSEIND] [bit] NULL,
	[CLOSEDDATE] [date] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ACCUST]    Script Date: 5/13/2016 6:00:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ACCUST](
	[COPNY] [varchar](2) NULL,
	[CUSTCODE] [varchar](10) NULL,
	[ACCNAME] [varchar](35) NULL,
	[ACADDR] [varchar](25) NULL,
	[ACAREA] [varchar](25) NULL,
	[ACTOWN] [varchar](25) NULL,
	[ACSTATE] [varchar](25) NULL,
	[ACCONTR] [varchar](1) NULL,
	[ACDUEDAY] [numeric](6, 2) NULL,
	[ACLIMIT] [numeric](15, 2) NULL,
	[ACVAT] [varchar](15) NULL,
	[TAXABLE] [char](1) NULL,
	[ACCTRAC] [varchar](10) NULL,
	[ACCDEBIT] [varchar](10) NULL,
	[ACPBAL] [numeric](15, 2) NULL,
	[ACPRBAL] [numeric](15, 2) NULL,
	[ACCURBAL] [numeric](15, 2) NULL,
	[ACLTRDATE] [datetime] NULL,
	[ACCUSTYPE] [varchar](1) NULL,
	[ACDISC] [numeric](6, 2) NULL,
	[ACDISCDAY] [numeric](6, 2) NULL,
	[PERIOD] [varchar](2) NULL,
	[MESSCODE] [varchar](3) NULL,
	[CONTACT] [varchar](25) NULL,
	[MDATEREG] [datetime] NULL,
	[MPHONE] [varchar](25) NULL,
	[MWEB] [varchar](25) NULL,
	[MEMAIL] [varchar](25) NULL,
	[LOCCODE] [varchar](4) NULL,
	[ACALTADDR] [varchar](100) NULL,
	[FAX] [varchar](20) NULL,
	[BISLINE] [varchar](10) NULL,
	[INVPICT] [varchar](70) NULL,
	[CACREGNO] [varchar](15) NULL,
	[TYPECODE] [varchar](10) NULL,
	[BANKCODE1] [nchar](20) NULL,
	[BRANCHCODE1] [nchar](20) NULL,
	[ACCOUNTID1] [nchar](25) NULL,
	[ACCTYPE] [nchar](25) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ACNOMHST]    Script Date: 5/13/2016 6:00:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ACNOMHST](
	[LNO] [varchar](2) NULL,
	[ACTRNO] [varchar](10) NOT NULL,
	[ACJCODE] [varchar](2) NOT NULL,
	[ACPERIOD] [varchar](2) NOT NULL,
	[ACYEAR] [varchar](4) NOT NULL,
	[ACTRDATE] [datetime] NOT NULL,
	[ACACTION] [varchar](1) NULL,
	[ACCODE] [varchar](10) NOT NULL,
	[POSTAC] [varchar](10) NOT NULL,
	[POSTCODE] [varchar](10) NOT NULL,
	[ACSUBCLASS] [varchar](10) NULL,
	[ACCLASS] [varchar](1) NULL,
	[ACTRDECR] [varchar](50) NULL,
	[TRANSCUR] [varchar](10) NULL,
	[CURRATE] [numeric](17, 3) NULL,
	[TRANSDEBIT] [numeric](17, 3) NULL,
	[TRANSCREDIT] [numeric](17, 3) NULL,
	[ACDEBIT] [numeric](17, 3) NULL,
	[ACCREDIT] [numeric](17, 3) NULL,
	[DRVALUE] [numeric](17, 3) NULL,
	[CRVALUE] [numeric](17, 3) NULL,
	[FORCUR] [varchar](10) NULL,
	[PROJECTT] [varchar](10) NULL,
	[COSTC] [varchar](10) NULL,
	[CUSTCODE] [varchar](10) NULL,
	[INVOICE] [varchar](20) NULL,
	[INVDATE] [datetime] NULL,
	[GRCODE] [varchar](3) NULL,
	[REMA] [varchar](15) NULL,
	[DATEIN] [datetime] NULL,
	[CERTNO] [varchar](10) NULL,
	[CERTY] [varchar](3) NULL,
	[LNO2] [varchar](3) NULL,
	[DATEPOST] [datetime] NULL,
	[Wherec] [varchar](10) NULL,
	[whatc] [varchar](10) NULL,
	[whoc] [varchar](10) NULL,
	[RETAMT] [numeric](17, 3) NULL,
	[VATONLY] [varchar](1) NULL,
	[GRIDCUR] [varchar](10) NULL,
	[GRIDCURRATE] [numeric](10, 4) NULL,
	[GRIDTRDEBIT] [numeric](17, 3) NULL,
	[GRIDTRCREDIT] [numeric](17, 3) NULL,
	[RATEACTION] [varchar](1) NULL,
	[STOCK] [numeric](17, 2) NULL,
	[UNITPRICE] [numeric](17, 3) NULL,
	[QTY] [numeric](17, 4) NULL,
	[VATPER] [numeric](8, 2) NULL,
	[VATAMT] [numeric](17, 3) NULL,
	[AMOUNT] [numeric](17, 3) NULL,
	[INBY] [varchar](10) NULL,
	[MODIBY] [varchar](10) NULL,
	[MODIDATE] [datetime] NULL,
	[MREF] [varchar](25) NULL,
	[POL_NO] [varchar](20) NULL,
	[acbank] [nchar](10) NULL,
	[SERNO] [numeric](18, 0) NOT NULL,
	[BANKC] [nchar](10) NULL,
	[rbalance] [numeric](17, 3) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ACNOMLEG]    Script Date: 5/13/2016 6:00:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ACNOMLEG](
	[LNO] [varchar](2) NULL,
	[ACTRNO] [char](10) NOT NULL,
	[ACJCODE] [char](10) NULL,
	[ACPERIOD] [char](10) NULL,
	[ACYEAR] [char](10) NULL,
	[ACTRDATE] [datetime] NULL,
	[ACACTION] [char](10) NULL,
	[ACCODE] [char](10) NULL,
	[POSTAC] [varchar](10) NULL,
	[POSTCODE] [varchar](10) NULL,
	[ACSUBCLASS] [char](10) NULL,
	[ACCLASS] [varchar](1) NULL,
	[ACTRDECR] [varchar](50) NULL,
	[TRANSCUR] [varchar](10) NULL,
	[CURRATE] [numeric](17, 3) NULL,
	[TRANSDEBIT] [numeric](17, 3) NULL,
	[TRANSCREDIT] [numeric](17, 3) NULL,
	[ACDEBIT] [numeric](17, 3) NULL,
	[ACCREDIT] [numeric](17, 3) NULL,
	[DRVALUE] [numeric](17, 3) NULL,
	[CRVALUE] [numeric](17, 3) NULL,
	[FORCUR] [varchar](10) NULL,
	[PROJECTT] [varchar](10) NULL,
	[COSTC] [varchar](10) NULL,
	[CUSTCODE] [varchar](10) NULL,
	[INVOICE] [varchar](20) NULL,
	[INVDATE] [datetime] NULL,
	[GRCODE] [varchar](3) NULL,
	[REMA] [varchar](15) NULL,
	[DATEIN] [datetime] NULL,
	[CERTNO] [varchar](6) NULL,
	[CERTY] [varchar](3) NULL,
	[LNO2] [varchar](3) NULL,
	[DATEPOST] [datetime] NULL,
	[wherec] [varchar](10) NULL,
	[whatc] [varchar](10) NULL,
	[whoc] [varchar](10) NULL,
	[RETAMT] [numeric](17, 3) NULL,
	[VATONLY] [varchar](1) NULL,
	[GRIDCUR] [varchar](10) NULL,
	[GRIDCURRATE] [numeric](10, 4) NULL,
	[GRIDTRDEBIT] [numeric](17, 3) NULL,
	[GRIDTRCREDIT] [numeric](17, 3) NULL,
	[RATEACTION] [varchar](1) NULL,
	[STOCK] [varchar](10) NULL,
	[UNITPRICE] [numeric](17, 3) NULL,
	[QTY] [numeric](7, 0) NULL,
	[VATPER] [numeric](7, 2) NULL,
	[VATAMT] [numeric](17, 3) NULL,
	[INBY] [varchar](10) NULL,
	[MODIBY] [varchar](10) NULL,
	[MODIDATE] [datetime] NULL,
	[MREF] [varchar](25) NULL,
	[POL_NO] [varchar](20) NULL,
	[SERNO] [numeric](18, 0) NOT NULL,
	[acbank] [char](10) NULL,
	[BANKC] [nchar](10) NULL,
	[rbalance] [numeric](17, 3) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ACRELATE]    Script Date: 5/13/2016 6:00:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ACRELATE](
	[ELEMENT2] [varchar](10) NULL,
	[ELEMENT3S] [varchar](10) NULL,
	[ELEMENT3E] [varchar](10) NULL,
	[ELEMENT4S] [varchar](10) NULL,
	[ELEMENT4E] [varchar](10) NULL,
	[ELEMENT5S] [varchar](10) NULL,
	[ELEMENT5E] [varchar](10) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ACSETTAB]    Script Date: 5/13/2016 6:00:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ACSETTAB](
	[GL] [varchar](1) NULL,
	[GLLENGTH] [numeric](3, 0) NULL,
	[GLDESCR] [varchar](30) NULL,
	[AUTOTRANS] [varchar](1) NULL,
	[CREDITOR] [varchar](1) NULL,
	[CREDITLEN] [numeric](3, 0) NULL,
	[CREDITDSCR] [varchar](30) NULL,
	[DEBTOR] [varchar](1) NULL,
	[DEBTORLEN] [numeric](3, 0) NULL,
	[DEBTORDSCR] [varchar](30) NULL,
	[PACKDATE] [datetime] NULL,
	[AUDITRATE] [numeric](3, 0) NULL,
	[OWNERCOMP] [varchar](2) NULL,
	[AUDITDEL] [numeric](3, 0) NULL,
	[NVOURCHER] [varchar](10) NULL,
	[ERELATE] [varchar](1) NULL,
	[BASECUR] [varchar](10) NULL,
	[EQUIACCT] [varchar](10) NULL,
	[ONLINEPOST] [varchar](1) NULL,
	[APPRJOURNAL] [varchar](1) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ACTAX]    Script Date: 5/13/2016 6:00:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ACTAX](
	[TAXCODE] [varchar](10) NOT NULL,
	[TAXDESC] [varchar](25) NULL,
	[TAXAC] [varchar](10) NOT NULL,
	[TAXRATE] [numeric](6, 2) NULL,
	[INTRDATE] [datetime] NULL,
	[PAIDTO] [varchar](25) NULL,
	[TAXTYPE] [numeric](1, 0) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Ailmenttypedefault]    Script Date: 5/13/2016 6:00:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Ailmenttypedefault](
	[code1] [char](20) NOT NULL,
	[descr] [char](80) NULL,
	[AMOUNT] [numeric](18, 2) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[appraisaltab]    Script Date: 5/13/2016 6:00:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[appraisaltab](
	[staffid] [char](15) NOT NULL,
	[names] [char](85) NULL,
	[appref] [char](55) NULL,
	[tdate] [datetime] NULL,
	[totalmark] [numeric](18, 0) NULL,
	[percentscore] [numeric](18, 0) NULL,
	[rating] [char](80) NULL,
	[staffagree] [char](8) NULL,
	[staffcomment] [char](85) NULL,
	[sdateresp] [datetime] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[assertdepre]    Script Date: 5/13/2016 6:00:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[assertdepre](
	[assertid] [char](15) NULL,
	[costassert] [numeric](18, 2) NULL,
	[ldate] [datetime] NULL,
	[depreciation] [numeric](18, 2) NULL,
	[networth] [numeric](18, 2) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[asserttab]    Script Date: 5/13/2016 6:00:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[asserttab](
	[assertid] [char](15) NOT NULL,
	[descr] [char](85) NULL,
	[asserttype] [char](15) NULL,
	[amount] [numeric](18, 2) NULL,
	[model] [char](25) NULL,
	[assertmake] [char](55) NULL,
	[regnumber] [char](15) NULL,
	[glcode] [char](15) NULL,
	[allocated] [bit] NULL,
	[allocstaff] [char](15) NULL,
	[dept] [char](15) NULL,
	[allocdate] [datetime] NULL,
	[assertstatus] [char](15) NULL,
	[purchasedate] [datetime] NULL,
	[regdate] [datetime] NULL,
	[mdepre] [numeric](18, 2) NULL,
	[cdepre] [numeric](18, 2) NULL,
	[rdepre] [numeric](18, 2) NULL,
	[ldepre] [numeric](18, 2) NULL,
	[networth] [numeric](18, 2) NULL,
	[lupdated] [datetime] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[audittab]    Script Date: 5/13/2016 6:00:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[audittab](
	[userid] [char](15) NOT NULL,
	[action1] [char](200) NULL,
	[period] [datetime] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[authorisgrid2]    Script Date: 5/13/2016 6:00:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[authorisgrid2](
	[enrolleeid] [char](15) NOT NULL,
	[codegen] [char](120) NULL,
	[gendate] [datetime] NULL,
	[smsto] [char](15) NULL,
	[hcpid] [char](15) NULL,
	[hcpname] [char](85) NULL,
	[email] [char](85) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BANKSETUP]    Script Date: 5/13/2016 6:00:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BANKSETUP](
	[BANKCODE] [nvarchar](20) NOT NULL,
	[sortcode] [nvarchar](20) NOT NULL,
	[NAMES] [nvarchar](120) NULL,
	[BRANCH] [char](80) NULL,
	[CMANAGER1] [nvarchar](30) NULL,
	[address] [char](120) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[claimsinpute]    Script Date: 5/13/2016 6:00:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[claimsinpute](
	[hcpid] [char](15) NOT NULL,
	[hcpname] [char](85) NULL,
	[tdate] [datetime] NULL,
	[batchcode] [char](15) NOT NULL,
	[enrolleeid] [char](15) NULL,
	[ailmentcode] [char](15) NULL,
	[authocode] [char](30) NULL,
	[dtreated] [datetime] NULL,
	[ddischard] [datetime] NULL,
	[defaultamt] [numeric](18, 2) NULL,
	[billamount] [numeric](18, 2) NULL,
	[variance] [numeric](18, 2) NULL,
	[posted] [bit] NULL,
	[postedto] [char](15) NULL,
	[approved] [bit] NULL,
	[postedforapprove] [bit] NULL,
	[appsendto] [char](80) NULL,
	[allertstop] [bit] NULL,
	[descrtype] [char](80) NULL,
	[enrollname] [char](80) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[claimsinputeApproved]    Script Date: 5/13/2016 6:00:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[claimsinputeApproved](
	[hcpid] [char](15) NOT NULL,
	[hcpname] [char](85) NULL,
	[tdate] [datetime] NULL,
	[batchcode] [char](15) NOT NULL,
	[enrolleeid] [char](15) NULL,
	[ailmentcode] [char](15) NULL,
	[authocode] [char](30) NULL,
	[dtreated] [datetime] NULL,
	[defaultamt] [numeric](18, 2) NULL,
	[billamount] [numeric](18, 2) NULL,
	[variance] [numeric](18, 2) NULL,
	[posted] [bit] NULL,
	[postedto] [char](15) NULL,
	[approved] [bit] NULL,
	[postedforapprove] [bit] NULL,
	[appsendto] [char](80) NULL,
	[mdapproves] [bit] NULL,
	[batchtotal] [numeric](18, 2) NULL,
	[paid] [bit] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[claimsinputenew]    Script Date: 5/13/2016 6:00:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[claimsinputenew](
	[batchcode] [char](15) NOT NULL,
	[hcpid] [char](15) NULL,
	[hcpname] [char](85) NULL,
	[tdate] [datetime] NULL,
	[enrolleeid] [char](15) NULL,
	[ailmentcode] [char](15) NULL,
	[dtreated] [datetime] NULL,
	[authocode] [char](25) NULL,
	[billamount] [numeric](18, 2) NULL,
	[total] [numeric](18, 2) NULL,
	[posted] [bit] NULL,
	[descrtype] [char](80) NULL,
	[enrollname] [char](80) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[codestab]    Script Date: 5/13/2016 6:00:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[codestab](
	[code1] [char](20) NOT NULL,
	[descr] [char](80) NULL,
	[option1] [char](5) NULL,
	[AMOUNT] [numeric](18, 2) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[companytab]    Script Date: 5/13/2016 6:00:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[companytab](
	[code1] [char](10) NOT NULL,
	[company] [char](200) NULL,
	[address] [char](200) NULL,
	[address2] [char](200) NULL,
	[tel] [char](200) NULL,
	[web] [char](90) NULL,
	[email] [char](200) NULL,
	[picpath] [char](200) NULL,
	[backgroundimg] [char](200) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CURTAB]    Script Date: 5/13/2016 6:00:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CURTAB](
	[CURCODE] [varchar](10) NOT NULL,
	[CURNAME] [varchar](20) NULL,
	[RATEN] [numeric](9, 4) NULL,
	[RATEDATE] [datetime] NOT NULL,
	[SYMBOL] [varchar](5) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 5/13/2016 6:00:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[customerid] [nchar](10) NULL,
	[city] [nchar](10) NULL,
	[country] [nchar](10) NULL,
	[tel] [nchar](10) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[custvendtab]    Script Date: 5/13/2016 6:00:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[custvendtab](
	[custvendid] [char](15) NOT NULL,
	[Names] [char](120) NULL,
	[custvendtype] [char](3) NULL,
	[cvtype] [char](15) NULL,
	[address] [char](180) NULL,
	[lga] [char](15) NULL,
	[dreg] [datetime] NULL,
	[website] [char](60) NULL,
	[email] [char](80) NULL,
	[spersontel] [char](80) NULL,
	[sperson] [char](80) NULL,
	[state] [char](15) NULL,
	[country] [char](15) NULL,
	[bankid] [char](15) NULL,
	[scode] [char](35) NULL,
	[bbranch] [char](55) NULL,
	[acctid] [char](25) NULL,
	[accttype] [char](20) NULL,
	[glcode] [char](15) NULL,
	[cbalance] [numeric](18, 2) NULL,
	[customersince] [date] NULL,
 CONSTRAINT [PK_custvendtab] PRIMARY KEY CLUSTERED 
(
	[custvendid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[datesetup]    Script Date: 5/13/2016 6:00:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[datesetup](
	[year1] [char](10) NULL,
	[month1] [numeric](18, 0) NULL,
	[days] [numeric](18, 0) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[defaulttab]    Script Date: 5/13/2016 6:00:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[defaulttab](
	[staffid] [char](15) NOT NULL,
	[pic] [char](10) NULL,
	[amount] [numeric](18, 2) NULL,
	[descr] [char](80) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[digitsettings]    Script Date: 5/13/2016 6:00:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[digitsettings](
	[bcodedidgit] [numeric](25, 0) NULL,
	[autocode] [char](30) NULL,
	[companyid] [char](15) NULL,
	[claimbatchcode] [char](30) NULL,
	[rptpath] [char](180) NULL,
	[photopath] [char](180) NULL,
	[docfolder] [char](180) NULL,
	[imgaepath] [char](180) NULL,
	[invoicepaytrig] [numeric](5, 0) NULL,
	[enrolleexptrig] [numeric](5, 0) NULL,
	[paymentapprovaltrig] [numeric](5, 0) NULL,
	[birthdaytrig] [numeric](5, 0) NULL,
	[cursymbol] [char](3) NULL,
	[deprciatn] [char](3) NULL,
	[invoiceno] [char](30) NULL,
	[accountname] [char](83) NULL,
	[bankname] [char](53) NULL,
	[branch] [char](43) NULL,
	[accountno] [char](13) NULL,
	[sortno] [char](13) NULL,
	[autorecieptno] [char](30) NULL,
	[paytcode] [char](30) NULL,
	[payref] [char](30) NULL,
	[portallink] [char](100) NULL,
	[appraisalref] [char](30) NULL,
	[leavref] [char](30) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[enrolleetab]    Script Date: 5/13/2016 6:00:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[enrolleetab](
	[enrolleeid] [char](15) NOT NULL,
	[Surname] [char](30) NULL,
	[Firstname] [char](30) NULL,
	[othernames] [char](40) NULL,
	[sex] [char](10) NULL,
	[Maritalstatus] [char](10) NULL,
	[title] [char](10) NULL,
	[haddress] [char](200) NULL,
	[age] [char](4) NULL,
	[dofb] [datetime] NULL,
	[tel] [char](100) NULL,
	[email] [char](100) NULL,
	[dregister] [datetime] NULL,
	[sdate] [datetime] NULL,
	[edate] [datetime] NULL,
	[active] [bit] NULL,
	[nationalid] [char](100) NULL,
	[NHIS] [char](100) NULL,
	[ogaid] [char](15) NULL,
	[ogaloc] [char](150) NULL,
	[ppicture] [char](180) NULL,
	[spicture] [char](180) NULL,
	[childpix1] [char](180) NULL,
	[childpix2] [char](180) NULL,
	[childpix3] [char](180) NULL,
	[childpix4] [char](180) NULL,
	[otherillness] [char](180) NULL,
	[illness1] [bit] NULL,
	[illness2] [bit] NULL,
	[illness3] [bit] NULL,
	[illness4] [bit] NULL,
	[illness5] [bit] NULL,
	[illness6] [bit] NULL,
	[illness7] [bit] NULL,
	[illness8] [bit] NULL,
	[illness9] [bit] NULL,
	[illness10] [bit] NULL,
	[illness11] [bit] NULL,
	[illness12] [bit] NULL,
	[illness13] [bit] NULL,
	[illness14] [bit] NULL,
	[illness15] [bit] NULL,
	[illness16] [bit] NULL,
	[illness17] [bit] NULL,
	[illness18] [bit] NULL,
	[illness19] [bit] NULL,
	[illness20] [bit] NULL,
	[hcpid] [char](15) NULL,
	[hcpname] [char](150) NULL,
	[hcpaddress] [char](185) NULL,
	[hcplga] [char](15) NULL,
	[sectortype] [char](15) NULL,
	[hplan] [char](15) NULL,
	[pnetwork] [char](15) NULL,
	[ugplan] [char](15) NULL,
	[ugmfees] [decimal](18, 2) NULL,
	[ugyfees] [decimal](18, 2) NULL,
	[ugstodate] [decimal](18, 2) NULL,
	[ugbalance] [decimal](18, 2) NULL,
	[drelated] [decimal](3, 0) NULL,
	[extra] [decimal](3, 0) NULL,
	[lpay] [decimal](18, 2) NULL,
 CONSTRAINT [PK_enrolleetab] PRIMARY KEY CLUSTERED 
(
	[enrolleeid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[enrolleetabimp]    Script Date: 5/13/2016 6:00:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[enrolleetabimp](
	[enrolleeid] [char](15) NOT NULL,
	[Surname] [char](30) NULL,
	[Firstname] [char](30) NULL,
	[othernames] [char](40) NULL,
	[sex] [char](10) NULL,
	[Maritalstatus] [char](10) NULL,
	[title] [char](10) NULL,
	[haddress] [char](200) NULL,
	[age] [char](4) NULL,
	[dofb] [datetime] NULL,
	[tel] [char](100) NULL,
	[email] [char](100) NULL,
	[dregister] [datetime] NULL,
	[sdate] [datetime] NULL,
	[edate] [datetime] NULL,
	[active] [bit] NULL,
	[nationalid] [char](100) NULL,
	[NHIS] [char](100) NULL,
	[ogaid] [char](15) NULL,
	[ogaloc] [char](150) NULL,
	[hcpid] [char](15) NULL,
	[hcpname] [char](150) NULL,
	[hcpaddress] [char](185) NULL,
	[hcplga] [char](15) NULL,
	[sectortype] [char](15) NULL,
	[hplan] [char](15) NULL,
	[pnetwork] [char](15) NULL,
	[ugplan] [char](15) NULL,
	[ugmfees] [decimal](18, 2) NULL,
	[ugyfees] [decimal](18, 2) NULL,
	[ugstodate] [decimal](18, 2) NULL,
	[ugbalance] [decimal](18, 2) NULL,
	[drelated] [decimal](3, 0) NULL,
	[extra] [decimal](3, 0) NULL,
	[recexist] [bit] NULL,
 CONSTRAINT [PK_enrolleetabimp] PRIMARY KEY CLUSTERED 
(
	[enrolleeid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[evaappraisdetail]    Script Date: 5/13/2016 6:00:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[evaappraisdetail](
	[staffid] [char](15) NOT NULL,
	[appref] [char](15) NULL,
	[appdesc] [char](45) NULL,
	[evadetail] [char](85) NULL,
	[maxmark] [numeric](3, 0) NULL,
	[mark] [numeric](3, 0) NULL,
	[respond] [char](65) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[evalitem]    Script Date: 5/13/2016 6:00:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[evalitem](
	[appcode] [char](20) NOT NULL,
	[appdesc] [char](30) NULL,
	[maxmark] [numeric](3, 0) NULL,
	[evadetail] [char](130) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[evalsignatory]    Script Date: 5/13/2016 6:00:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[evalsignatory](
	[staffid] [char](15) NOT NULL,
	[appref] [char](15) NULL,
	[position] [char](15) NULL,
	[tdate] [datetime] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Familyinfo]    Script Date: 5/13/2016 6:00:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Familyinfo](
	[ftype] [char](15) NULL,
	[names] [char](150) NULL,
	[alterHCP] [char](120) NULL,
	[dofb] [datetime] NULL,
	[age] [char](3) NULL,
	[sex] [char](7) NULL,
	[Enrolleeid] [char](20) NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Familypics]    Script Date: 5/13/2016 6:00:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Familypics](
	[principal] [char](200) NULL,
	[spouse] [char](200) NULL,
	[child1] [char](200) NULL,
	[child2] [char](200) NULL,
	[child3] [char](200) NULL,
	[child4] [char](200) NULL,
	[EnrolleeID] [char](20) NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[gencapitation]    Script Date: 5/13/2016 6:00:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[gencapitation](
	[hcpid] [char](15) NOT NULL,
	[hcpname] [char](85) NULL,
	[principal] [numeric](18, 2) NULL,
	[dependant] [numeric](18, 2) NULL,
	[extra] [numeric](18, 2) NULL,
	[totallives] [numeric](18, 2) NULL,
	[capitationrate] [numeric](18, 2) NULL,
	[capitation] [numeric](18, 2) NULL,
	[dateperiod] [datetime] NULL,
	[tcode] [char](15) NULL,
	[posted] [bit] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[hcpailmenttab]    Script Date: 5/13/2016 6:00:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[hcpailmenttab](
	[code] [char](15) NOT NULL,
	[descr] [char](150) NULL,
	[amount] [numeric](18, 2) NULL,
	[hcpid] [char](15) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Hcptab]    Script Date: 5/13/2016 6:00:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Hcptab](
	[hcpid] [char](15) NOT NULL,
	[Names] [char](150) NULL,
	[dregister] [datetime] NULL,
	[active] [bit] NULL,
	[NHIS] [char](15) NULL,
	[LGA] [char](15) NULL,
	[state] [char](15) NULL,
	[country] [char](15) NULL,
	[pmethod] [char](25) NULL,
	[tel] [char](55) NULL,
	[email] [char](75) NULL,
	[website] [char](105) NULL,
	[address] [char](150) NULL,
	[glcode] [char](25) NULL,
	[bank] [char](15) NULL,
	[bankbranch] [char](105) NULL,
	[accid] [char](85) NULL,
	[sortcode] [char](15) NULL,
	[Mdnames] [char](105) NULL,
	[mdtel] [char](55) NULL,
	[mdemail] [char](85) NULL,
	[sectortype] [char](15) NULL,
	[hcpplan] [char](15) NULL,
	[pnetwork] [char](15) NULL,
	[lpay] [numeric](18, 2) NULL,
	[paidtodate] [numeric](18, 2) NULL,
 CONSTRAINT [PK_Hcptab] PRIMARY KEY CLUSTERED 
(
	[hcpid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Hcptabimp]    Script Date: 5/13/2016 6:00:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Hcptabimp](
	[hcpid] [char](15) NOT NULL,
	[Names] [char](150) NULL,
	[dregister] [datetime] NULL,
	[active] [bit] NULL,
	[NHIS] [char](15) NULL,
	[LGA] [char](15) NULL,
	[state] [char](15) NULL,
	[country] [char](15) NULL,
	[pmethod] [char](25) NULL,
	[tel] [char](55) NULL,
	[email] [char](75) NULL,
	[website] [char](105) NULL,
	[address] [char](150) NULL,
	[glcode] [char](25) NULL,
	[bank] [char](15) NULL,
	[bankbranch] [char](105) NULL,
	[accid] [char](85) NULL,
	[sortcode] [char](15) NULL,
	[Mdnames] [char](105) NULL,
	[mdtel] [char](55) NULL,
	[mdemail] [char](85) NULL,
	[sectortype] [char](15) NULL,
	[hcpplan] [char](15) NULL,
	[pnetwork] [char](15) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[leavetab]    Script Date: 5/13/2016 6:00:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[leavetab](
	[staffid] [char](15) NOT NULL,
	[leaveref] [char](15) NOT NULL,
	[names] [char](85) NULL,
	[leaveadd] [char](150) NULL,
	[leavetype] [char](15) NULL,
	[tel] [char](25) NULL,
	[leaveentile] [numeric](8, 2) NULL,
	[apprvnleavedays] [numeric](8, 2) NULL,
	[leavebal] [numeric](8, 2) NULL,
	[resumeat] [char](55) NULL,
	[anualsal] [numeric](18, 2) NULL,
	[sldate] [datetime] NULL,
	[eldate] [datetime] NULL,
	[leavemode] [char](15) NULL,
	[signby] [char](15) NULL,
	[approved] [bit] NULL,
	[ccmd] [char](15) NULL,
	[ccothers] [char](15) NULL,
	[resumedate] [datetime] NULL,
	[daysused] [numeric](8, 2) NULL,
	[appby] [char](15) NULL,
	[appnow] [bit] NULL,
	[ltypedescr] [char](85) NULL,
	[ccmdnames] [char](85) NULL,
	[ccothersnames] [char](85) NULL,
	[appbynames] [char](85) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[loantab]    Script Date: 5/13/2016 6:00:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[loantab](
	[staffid] [char](15) NOT NULL,
	[pic] [char](15) NULL,
	[descr] [char](85) NULL,
	[amtcollected] [numeric](18, 2) NULL,
	[dcollected] [datetime] NULL,
	[sdate] [datetime] NULL,
	[mpayment] [numeric](18, 2) NULL,
	[pperiod] [char](10) NULL,
	[premaining] [char](10) NULL,
	[paidtoadate] [numeric](18, 2) NULL,
	[stopped] [bit] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[menutable]    Script Date: 5/13/2016 6:00:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[menutable](
	[menucode] [char](10) NOT NULL,
	[menuname] [char](120) NULL,
	[available] [bit] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[nextofkin]    Script Date: 5/13/2016 6:00:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[nextofkin](
	[staffid] [char](10) NOT NULL,
	[Nkinnames] [char](120) NULL,
	[address] [char](150) NULL,
	[tel] [char](50) NULL,
	[rela] [char](20) NULL,
	[allocation] [numeric](18, 2) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[oganisationtab]    Script Date: 5/13/2016 6:00:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[oganisationtab](
	[ogaid] [char](15) NOT NULL,
	[oganames] [char](150) NULL,
	[active] [bit] NULL,
	[dregister] [datetime] NULL,
	[lga] [char](15) NULL,
	[state] [char](15) NULL,
	[country] [char](15) NULL,
	[tel] [char](85) NULL,
	[email] [char](85) NULL,
	[website] [char](85) NULL,
	[sperson] [char](150) NULL,
	[address] [char](180) NULL,
	[glcode] [char](15) NULL,
	[bank] [char](15) NULL,
	[bankbranch] [char](150) NULL,
	[accountid] [char](85) NULL,
	[sortcode] [char](25) NULL,
	[sectortype] [char](15) NULL,
	[hcpplan] [char](15) NULL,
	[puprice] [numeric](18, 2) NULL,
	[punumber] [numeric](18, 2) NULL,
	[putotal] [numeric](18, 2) NULL,
	[pugrandtotal] [numeric](18, 2) NULL,
	[ugplan] [char](15) NULL,
	[Utidefaultfees] [numeric](18, 2) NULL,
	[paidtodate] [numeric](18, 2) NULL,
 CONSTRAINT [PK_oganisationtab] PRIMARY KEY CLUSTERED 
(
	[ogaid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[oganisationtabimp]    Script Date: 5/13/2016 6:00:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[oganisationtabimp](
	[ogaid] [char](15) NOT NULL,
	[oganames] [char](150) NULL,
	[active] [bit] NULL,
	[dregister] [datetime] NULL,
	[lga] [char](15) NULL,
	[state] [char](15) NULL,
	[country] [char](15) NULL,
	[tel] [char](85) NULL,
	[email] [char](85) NULL,
	[website] [char](85) NULL,
	[sperson] [char](150) NULL,
	[address] [char](180) NULL,
	[glcode] [char](15) NULL,
	[bank] [char](15) NULL,
	[bankbranch] [char](150) NULL,
	[accountid] [char](85) NULL,
	[sortcode] [char](25) NULL,
	[sectortype] [char](15) NULL,
	[hcpplan] [char](15) NULL,
	[puprice] [numeric](18, 2) NULL,
	[punumber] [numeric](18, 2) NULL,
	[putotal] [numeric](18, 2) NULL,
	[pugrandtotal] [numeric](18, 2) NULL,
	[ugplan] [char](15) NULL,
	[Utidefaultfees] [numeric](18, 2) NULL,
 CONSTRAINT [PK_oganisationtabimp] PRIMARY KEY CLUSTERED 
(
	[ogaid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ogaplangrid]    Script Date: 5/13/2016 6:00:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ogaplangrid](
	[code1] [char](15) NULL,
	[descr] [char](150) NULL,
	[ninplan] [numeric](18, 0) NULL,
	[uprice] [numeric](18, 2) NULL,
	[amount] [numeric](18, 2) NULL,
	[ogaid] [char](15) NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[payhst]    Script Date: 5/13/2016 6:00:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[payhst](
	[staffid] [char](18) NOT NULL,
	[Names] [char](80) NULL,
	[pic] [char](10) NULL,
	[itemdescr] [char](50) NULL,
	[pictype] [char](10) NULL,
	[taxable] [bit] NULL,
	[scheme] [bit] NULL,
	[advance] [bit] NULL,
	[gradelvl] [char](10) NULL,
	[deptcode] [char](10) NULL,
	[bankid] [char](10) NULL,
	[accountid] [char](10) NULL,
	[pamount] [numeric](15, 2) NULL,
	[period] [numeric](2, 0) NULL,
	[paycaldate] [datetime] NULL,
	[year] [numeric](4, 0) NULL,
	[month] [numeric](2, 0) NULL,
	[fixedtax] [numeric](15, 2) NULL,
	[totalallowance] [numeric](15, 2) NULL,
	[totaldeduction] [numeric](15, 2) NULL,
	[netpay] [numeric](15, 2) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Payinvoice]    Script Date: 5/13/2016 6:00:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Payinvoice](
	[billcode] [char](15) NOT NULL,
	[descr] [char](85) NULL,
	[invoicetopic] [nvarchar](max) NULL,
	[tdate] [datetime] NULL,
	[invoiceno] [char](15) NULL,
	[glcode] [char](15) NULL,
	[Amtword] [char](180) NULL,
	[salesrep] [char](15) NULL,
	[stax] [numeric](18, 2) NULL,
	[itotal] [numeric](18, 2) NULL,
	[netdue] [numeric](18, 2) NULL,
	[addressto] [nvarchar](max) NULL,
	[signby] [nvarchar](max) NULL,
	[discounttot] [numeric](18, 2) NULL,
	[accountname] [char](80) NULL,
	[accountno] [char](18) NULL,
	[bankname] [char](60) NULL,
	[sortno] [char](18) NULL,
	[branch] [char](40) NULL,
	[discount2] [numeric](18, 2) NULL,
	[paid] [bit] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[payitems]    Script Date: 5/13/2016 6:00:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[payitems](
	[itemcode] [char](10) NOT NULL,
	[itemdescr] [char](90) NULL,
	[itemtype] [char](10) NULL,
	[advance] [bit] NULL,
	[scheme] [bit] NULL,
	[taxable] [bit] NULL,
	[glcode] [char](10) NULL,
	[acmode] [char](10) NULL,
	[pay] [bit] NULL,
 CONSTRAINT [PK_payitems] PRIMARY KEY CLUSTERED 
(
	[itemcode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[payment]    Script Date: 5/13/2016 6:00:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[payment](
	[paycode] [char](15) NOT NULL,
	[paybank] [char](15) NULL,
	[totalpayment] [numeric](18, 2) NULL,
	[mcid] [char](15) NULL,
	[pmethod] [char](25) NULL,
	[tdate] [datetime] NULL,
	[glcode] [char](15) NULL,
	[paid] [bit] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[paysum]    Script Date: 5/13/2016 6:00:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[paysum](
	[staffid] [char](18) NOT NULL,
	[Names] [char](80) NULL,
	[pic] [char](10) NULL,
	[itemdescr] [char](50) NULL,
	[pictype] [char](10) NULL,
	[taxable] [bit] NULL,
	[scheme] [bit] NULL,
	[advance] [bit] NULL,
	[gradelvl] [char](10) NULL,
	[deptcode] [char](10) NULL,
	[bankid] [char](10) NULL,
	[accountid] [char](10) NULL,
	[pamount] [numeric](15, 2) NULL,
	[period] [numeric](2, 0) NULL,
	[paycaldate] [datetime] NULL,
	[year] [numeric](4, 0) NULL,
	[month] [numeric](2, 0) NULL,
	[fixedtax] [numeric](15, 2) NULL,
	[totalallowance] [numeric](15, 2) NULL,
	[totaldeduction] [numeric](15, 2) NULL,
	[netpay] [numeric](15, 2) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[pinvoicegrid]    Script Date: 5/13/2016 6:00:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[pinvoicegrid](
	[invoiceno] [char](15) NOT NULL,
	[ddate] [datetime] NULL,
	[amtdue] [numeric](18, 2) NULL,
	[descr] [char](85) NULL,
	[discount] [numeric](18, 2) NULL,
	[amtpaid] [numeric](18, 2) NULL,
	[pay] [bit] NULL,
	[vbank] [char](15) NULL,
	[pdescr] [char](55) NULL,
	[paycode] [char](25) NULL,
	[hcpid] [char](25) NULL,
	[hcpname] [char](55) NULL,
	[bank] [char](25) NULL,
	[bankbranch] [char](55) NULL,
	[accid] [char](25) NULL,
	[sortcode] [char](25) NULL,
	[email] [char](85) NULL,
	[payref] [char](25) NULL,
	[totalpayment] [numeric](18, 2) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[premiumplan]    Script Date: 5/13/2016 6:00:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[premiumplan](
	[code1] [char](20) NOT NULL,
	[descr] [char](80) NULL,
	[AMOUNT] [numeric](18, 2) NULL,
	[Type] [char](15) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[qualification]    Script Date: 5/13/2016 6:00:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[qualification](
	[staffid] [char](15) NOT NULL,
	[quali] [char](85) NULL,
	[div] [char](85) NULL,
	[year] [char](8) NULL,
	[course] [char](85) NULL,
	[dsubmitted] [datetime] NULL,
	[enrty] [char](85) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[reports]    Script Date: 5/13/2016 6:00:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[reports](
	[reportid] [char](4) NOT NULL,
	[reportname] [char](70) NULL,
	[type] [char](10) NULL,
	[awitch] [bit] NULL,
	[orderby] [numeric](18, 0) NULL,
 CONSTRAINT [PK_reports] PRIMARY KEY CLUSTERED 
(
	[reportid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[reward]    Script Date: 5/13/2016 6:00:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[reward](
	[code] [char](5) NOT NULL,
	[desc1] [char](20) NULL,
	[begin1] [numeric](3, 0) NULL,
	[end1] [numeric](3, 0) NULL,
	[option1] [numeric](1, 0) NULL,
	[rwdcode] [char](5) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[salesinvoice]    Script Date: 5/13/2016 6:00:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[salesinvoice](
	[billcode] [char](15) NOT NULL,
	[descr] [char](85) NULL,
	[invoicetopic] [nvarchar](max) NULL,
	[tdate] [datetime] NULL,
	[invoiceno] [char](15) NULL,
	[glcode] [char](15) NULL,
	[Amtword] [char](180) NULL,
	[salesrep] [char](15) NULL,
	[stax] [numeric](18, 2) NULL,
	[itotal] [numeric](18, 2) NULL,
	[netdue] [numeric](18, 2) NULL,
	[addressto] [nvarchar](max) NULL,
	[signby] [nvarchar](max) NULL,
	[discounttot] [numeric](18, 2) NULL,
	[accountname] [char](80) NULL,
	[accountno] [char](18) NULL,
	[bankname] [char](60) NULL,
	[sortno] [char](18) NULL,
	[branch] [char](40) NULL,
	[discount2] [numeric](18, 2) NULL,
	[paid] [bit] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[salesinvoicerpt]    Script Date: 5/13/2016 6:00:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[salesinvoicerpt](
	[billcode] [char](15) NOT NULL,
	[descr] [char](85) NULL,
	[invoicetopic] [nvarchar](max) NULL,
	[tdate] [datetime] NULL,
	[invoiceno] [char](15) NULL,
	[glcode] [char](15) NULL,
	[Amtword] [char](180) NULL,
	[salesrep] [char](15) NULL,
	[stax] [numeric](18, 2) NULL,
	[itotal] [numeric](18, 2) NULL,
	[netdue] [numeric](18, 2) NULL,
	[addressto] [nvarchar](max) NULL,
	[signby] [nvarchar](max) NULL,
	[discounttot] [numeric](18, 2) NULL,
	[accountname] [char](80) NULL,
	[accountno] [char](18) NULL,
	[bankname] [char](60) NULL,
	[sortno] [char](18) NULL,
	[branch] [char](40) NULL,
	[discount2] [numeric](18, 2) NULL,
	[code1] [char](18) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[salesreceipt]    Script Date: 5/13/2016 6:00:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[salesreceipt](
	[billcode] [char](15) NOT NULL,
	[descr] [char](85) NULL,
	[issuedate] [datetime] NULL,
	[invoiceno] [char](15) NULL,
	[glcode] [char](15) NULL,
	[Amtword] [nvarchar](max) NULL,
	[salesrep] [char](15) NULL,
	[stax] [numeric](18, 2) NULL,
	[itotal] [numeric](18, 2) NULL,
	[netdue] [numeric](18, 2) NULL,
	[collectedfrom] [char](180) NULL,
	[paid] [bit] NULL,
	[pmethod] [char](25) NULL,
	[chequeref] [char](35) NULL,
	[recieptno] [char](35) NULL,
	[ramt] [numeric](18, 2) NULL,
	[discount2] [numeric](18, 2) NULL,
	[beingpart] [nvarchar](max) NULL,
	[code1] [char](15) NULL,
	[partbalace] [numeric](18, 2) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[setuptab]    Script Date: 5/13/2016 6:00:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[setuptab](
	[Dcapscrooltect] [char](250) NULL,
	[Payrate] [numeric](18, 2) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[sinvoicegrid]    Script Date: 5/13/2016 6:00:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[sinvoicegrid](
	[invoiceno] [char](15) NOT NULL,
	[pcode] [char](105) NULL,
	[eqty] [numeric](18, 2) NULL,
	[uprice] [numeric](18, 2) NULL,
	[tax] [numeric](18, 2) NULL,
	[discount] [numeric](18, 2) NULL,
	[amt] [numeric](18, 2) NULL,
	[pdescr] [char](85) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[sinvoicegridrpt]    Script Date: 5/13/2016 6:00:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[sinvoicegridrpt](
	[invoiceno] [char](15) NOT NULL,
	[pcode] [char](105) NULL,
	[eqty] [numeric](18, 2) NULL,
	[uprice] [numeric](18, 2) NULL,
	[tax] [numeric](18, 2) NULL,
	[discount] [numeric](18, 2) NULL,
	[amt] [numeric](18, 2) NULL,
	[pdescr] [char](85) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[stafftab]    Script Date: 5/13/2016 6:00:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[stafftab](
	[staffid] [char](25) NOT NULL,
	[surname] [char](50) NULL,
	[firstname] [char](100) NULL,
	[othernames] [char](80) NULL,
	[title] [char](15) NULL,
	[sex] [char](8) NULL,
	[mstatus] [char](15) NULL,
	[dengage] [datetime] NULL,
	[dofb] [datetime] NULL,
	[age] [char](5) NULL,
	[tel] [char](95) NULL,
	[email] [char](95) NULL,
	[pofb] [char](85) NULL,
	[natid] [char](45) NULL,
	[address] [char](205) NULL,
	[pfa] [char](15) NULL,
	[lga] [char](15) NULL,
	[state] [char](10) NULL,
	[country] [char](15) NULL,
	[cat] [char](15) NULL,
	[position] [char](15) NULL,
	[glevel] [char](15) NULL,
	[bankid] [char](15) NULL,
	[branch] [char](15) NULL,
	[dept] [char](15) NULL,
	[accountid] [char](35) NULL,
	[accttype] [char](30) NULL,
	[scode] [char](30) NULL,
	[suspended] [bit] NULL,
	[leavedays] [numeric](18, 2) NULL,
	[leavebal] [numeric](18, 2) NULL,
	[officebranch] [nchar](10) NULL,
	[lpromotedd] [datetime] NULL,
	[suspendeddate] [datetime] NULL,
	[ppicture] [char](120) NULL,
	[spicture] [char](120) NULL,
	[childpix1] [char](120) NULL,
	[childpix2] [char](120) NULL,
	[childpix3] [char](120) NULL,
	[childpix4] [char](120) NULL,
 CONSTRAINT [PK_stafftab] PRIMARY KEY CLUSTERED 
(
	[staffid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[summarytab]    Script Date: 5/13/2016 6:00:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[summarytab](
	[staffid] [char](15) NOT NULL,
	[names] [char](80) NULL,
	[fixedtax] [numeric](18, 2) NULL,
	[grosstd] [numeric](18, 2) NULL,
	[taxtd] [numeric](18, 2) NULL,
	[totalallowance] [numeric](18, 2) NULL,
	[totaldeduction] [numeric](18, 2) NULL,
	[netpay] [numeric](18, 2) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[summarytabhst]    Script Date: 5/13/2016 6:00:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[summarytabhst](
	[staffid] [char](15) NOT NULL,
	[names] [char](80) NULL,
	[fixedtax] [numeric](18, 2) NULL,
	[grosstd] [numeric](18, 2) NULL,
	[taxtd] [numeric](18, 2) NULL,
	[totalallowance] [numeric](18, 2) NULL,
	[totaldeduction] [numeric](18, 2) NULL,
	[netpay] [numeric](18, 2) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[transtab]    Script Date: 5/13/2016 6:00:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[transtab](
	[headcode] [char](15) NULL,
	[hdescr] [char](100) NOT NULL,
	[transcode] [char](10) NULL,
	[tdescr] [char](100) NULL,
	[typecode] [char](3) NULL,
	[qty] [numeric](13, 2) NULL,
	[uprice] [numeric](13, 2) NULL,
	[total] [numeric](13, 2) NULL,
	[transdate] [datetime] NULL,
	[acctcredit] [char](3) NULL,
	[acctdebit] [char](15) NULL,
	[post] [bit] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[useracct]    Script Date: 5/13/2016 6:00:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[useracct](
	[userid] [char](15) NOT NULL,
	[password] [char](50) NULL,
	[names] [char](150) NULL,
	[admin] [bit] NULL,
	[status] [bit] NULL,
	[appraise] [bit] NULL,
	[approve] [bit] NULL,
	[staffonline] [bit] NULL,
	[staffpin] [char](50) NULL,
	[claimsinput] [bit] NULL,
	[claimsvetting] [bit] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[usersmenu]    Script Date: 5/13/2016 6:00:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[usersmenu](
	[userid] [char](18) NOT NULL,
	[menucode] [char](10) NULL,
	[menuname] [nchar](120) NULL,
	[available] [bit] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[ACCTPERIOD] ([ACPERIOD], [ACYEAR], [OPENDATE], [CLOSEDATE], [CLOSEIND], [CLOSEDDATE]) VALUES (N'01', N'2016', CAST(N'2016-01-01' AS Date), CAST(N'2016-01-31' AS Date), 1, CAST(N'2016-01-31' AS Date))
INSERT [dbo].[ACCTPERIOD] ([ACPERIOD], [ACYEAR], [OPENDATE], [CLOSEDATE], [CLOSEIND], [CLOSEDDATE]) VALUES (N'02', N'2016', CAST(N'2016-02-01' AS Date), CAST(N'2016-02-29' AS Date), 1, CAST(N'2016-02-27' AS Date))
INSERT [dbo].[ACCTPERIOD] ([ACPERIOD], [ACYEAR], [OPENDATE], [CLOSEDATE], [CLOSEIND], [CLOSEDDATE]) VALUES (N'03', N'2016', CAST(N'2016-03-01' AS Date), CAST(N'2016-03-31' AS Date), 0, CAST(N'2016-02-27' AS Date))
INSERT [dbo].[ACCTPERIOD] ([ACPERIOD], [ACYEAR], [OPENDATE], [CLOSEDATE], [CLOSEIND], [CLOSEDDATE]) VALUES (N'04', N'2016', CAST(N'2016-04-01' AS Date), CAST(N'2016-04-30' AS Date), 0, CAST(N'2016-02-27' AS Date))
INSERT [dbo].[ACCTPERIOD] ([ACPERIOD], [ACYEAR], [OPENDATE], [CLOSEDATE], [CLOSEIND], [CLOSEDDATE]) VALUES (N'05', N'2016', CAST(N'2016-05-01' AS Date), CAST(N'2016-05-31' AS Date), 0, CAST(N'2016-02-27' AS Date))
INSERT [dbo].[ACCTPERIOD] ([ACPERIOD], [ACYEAR], [OPENDATE], [CLOSEDATE], [CLOSEIND], [CLOSEDDATE]) VALUES (N'06', N'2016', CAST(N'2016-06-01' AS Date), CAST(N'2016-06-30' AS Date), 0, CAST(N'2016-02-27' AS Date))
INSERT [dbo].[ACCTPERIOD] ([ACPERIOD], [ACYEAR], [OPENDATE], [CLOSEDATE], [CLOSEIND], [CLOSEDDATE]) VALUES (N'07', N'2016', CAST(N'2016-07-01' AS Date), CAST(N'2016-07-31' AS Date), 0, CAST(N'2016-02-27' AS Date))
INSERT [dbo].[ACCTPERIOD] ([ACPERIOD], [ACYEAR], [OPENDATE], [CLOSEDATE], [CLOSEIND], [CLOSEDDATE]) VALUES (N'08', N'2016', CAST(N'2016-08-01' AS Date), CAST(N'2016-08-31' AS Date), 0, CAST(N'2016-02-27' AS Date))
INSERT [dbo].[ACCTPERIOD] ([ACPERIOD], [ACYEAR], [OPENDATE], [CLOSEDATE], [CLOSEIND], [CLOSEDDATE]) VALUES (N'09', N'2016', CAST(N'2016-09-01' AS Date), CAST(N'2016-09-30' AS Date), 0, CAST(N'2016-02-27' AS Date))
INSERT [dbo].[ACCTPERIOD] ([ACPERIOD], [ACYEAR], [OPENDATE], [CLOSEDATE], [CLOSEIND], [CLOSEDDATE]) VALUES (N'10', N'2016', CAST(N'2016-10-01' AS Date), CAST(N'2016-10-31' AS Date), 0, CAST(N'2016-02-27' AS Date))
INSERT [dbo].[ACCTPERIOD] ([ACPERIOD], [ACYEAR], [OPENDATE], [CLOSEDATE], [CLOSEIND], [CLOSEDDATE]) VALUES (N'11', N'2016', CAST(N'2016-11-01' AS Date), CAST(N'2016-11-30' AS Date), 0, CAST(N'2016-02-27' AS Date))
INSERT [dbo].[ACCTPERIOD] ([ACPERIOD], [ACYEAR], [OPENDATE], [CLOSEDATE], [CLOSEIND], [CLOSEDDATE]) VALUES (N'12', N'2016', CAST(N'2016-12-01' AS Date), CAST(N'2016-12-31' AS Date), 0, CAST(N'2016-02-27' AS Date))
INSERT [dbo].[Ailmenttypedefault] ([code1], [descr], [AMOUNT]) VALUES (N'IL001               ', N'Sickle cell disease                                                             ', CAST(14000.00 AS Numeric(18, 2)))
INSERT [dbo].[Ailmenttypedefault] ([code1], [descr], [AMOUNT]) VALUES (N'IL002               ', N'Diabetes Mellitu                                                                ', CAST(5000.00 AS Numeric(18, 2)))
INSERT [dbo].[Ailmenttypedefault] ([code1], [descr], [AMOUNT]) VALUES (N'IL003               ', N'Viral Hepatitis                                                                 ', CAST(30000.00 AS Numeric(18, 2)))
INSERT [dbo].[Ailmenttypedefault] ([code1], [descr], [AMOUNT]) VALUES (N'IL004               ', N'CANCER                                                                          ', CAST(14000.00 AS Numeric(18, 2)))
INSERT [dbo].[Ailmenttypedefault] ([code1], [descr], [AMOUNT]) VALUES (N'IL007               ', N'CONSULTATION                                                                    ', CAST(40000.00 AS Numeric(18, 2)))
INSERT [dbo].[Ailmenttypedefault] ([code1], [descr], [AMOUNT]) VALUES (N'IL008               ', N'DRUGS                                                                           ', CAST(0.00 AS Numeric(18, 2)))
INSERT [dbo].[Ailmenttypedefault] ([code1], [descr], [AMOUNT]) VALUES (N'IL009               ', N'LABSERVICES                                                                     ', CAST(0.00 AS Numeric(18, 2)))
INSERT [dbo].[Ailmenttypedefault] ([code1], [descr], [AMOUNT]) VALUES (N'IL010               ', N'ADMISSION                                                                       ', CAST(0.00 AS Numeric(18, 2)))
INSERT [dbo].[Ailmenttypedefault] ([code1], [descr], [AMOUNT]) VALUES (N'IL011               ', N'XRAY                                                                            ', CAST(0.00 AS Numeric(18, 2)))
INSERT [dbo].[Ailmenttypedefault] ([code1], [descr], [AMOUNT]) VALUES (N'IL012               ', N'SURGERY                                                                         ', CAST(0.00 AS Numeric(18, 2)))
INSERT [dbo].[audittab] ([userid], [action1], [period]) VALUES (N'ADMIN          ', N'Login into the system                                                                                                                                                                                   ', CAST(N'2016-05-13 10:20:45.000' AS DateTime))
INSERT [dbo].[audittab] ([userid], [action1], [period]) VALUES (N'ADMIN          ', N'Update account of User id : ADMIN                                                                                                                                                                       ', CAST(N'2016-05-13 10:21:45.000' AS DateTime))
INSERT [dbo].[audittab] ([userid], [action1], [period]) VALUES (N'ADMIN          ', N'Login into the system                                                                                                                                                                                   ', CAST(N'2016-05-13 10:21:57.000' AS DateTime))
INSERT [dbo].[audittab] ([userid], [action1], [period]) VALUES (N'ADMIN          ', N'Insert new record for Staffid : UH004 In Staff Information                                                                                                                                              ', CAST(N'2016-05-13 10:28:02.000' AS DateTime))
INSERT [dbo].[audittab] ([userid], [action1], [period]) VALUES (N'ADMIN          ', N'Create account for User id : UH004                                                                                                                                                                      ', CAST(N'2016-05-13 10:29:52.000' AS DateTime))
INSERT [dbo].[audittab] ([userid], [action1], [period]) VALUES (N'UH004          ', N'Login into the system                                                                                                                                                                                   ', CAST(N'2016-05-13 10:30:17.000' AS DateTime))
INSERT [dbo].[audittab] ([userid], [action1], [period]) VALUES (N'UH004          ', N'Login into the system                                                                                                                                                                                   ', CAST(N'2016-05-13 10:51:02.000' AS DateTime))
INSERT [dbo].[audittab] ([userid], [action1], [period]) VALUES (N'UH004          ', N'Insert new record for Staffid : UH005 In Staff Information                                                                                                                                              ', CAST(N'2016-05-13 10:51:36.000' AS DateTime))
INSERT [dbo].[audittab] ([userid], [action1], [period]) VALUES (N'ADMIN          ', N'Login into the system                                                                                                                                                                                   ', CAST(N'2016-05-13 12:44:47.000' AS DateTime))
INSERT [dbo].[audittab] ([userid], [action1], [period]) VALUES (N'ADMIN          ', N'Login into the system                                                                                                                                                                                   ', CAST(N'2016-05-13 13:34:52.000' AS DateTime))
INSERT [dbo].[audittab] ([userid], [action1], [period]) VALUES (N'ADMIN          ', N'Insert new record for Staffid : UH007 In Staff Information                                                                                                                                              ', CAST(N'2016-05-13 13:35:27.000' AS DateTime))
INSERT [dbo].[audittab] ([userid], [action1], [period]) VALUES (N'ADMIN          ', N'Login into the system                                                                                                                                                                                   ', CAST(N'2016-05-13 16:55:07.000' AS DateTime))
INSERT [dbo].[audittab] ([userid], [action1], [period]) VALUES (N'ADMIN          ', N'Insert new record for Pay Item code: P1078 In Payitems Setup                                                                                                                                            ', CAST(N'2016-05-13 16:57:37.000' AS DateTime))
INSERT [dbo].[audittab] ([userid], [action1], [period]) VALUES (N'ADMIN          ', N'Insert new record for Pay Item code: P1079 In Payitems Setup                                                                                                                                            ', CAST(N'2016-05-13 16:58:09.000' AS DateTime))
INSERT [dbo].[audittab] ([userid], [action1], [period]) VALUES (N'ADMIN          ', N'Insert new record for Pay Item code: P1085 In Payitems Setup                                                                                                                                            ', CAST(N'2016-05-13 17:04:08.000' AS DateTime))
INSERT [dbo].[audittab] ([userid], [action1], [period]) VALUES (N'ADMIN          ', N'Insert new record for Pay Item code: P1086 In Payitems Setup                                                                                                                                            ', CAST(N'2016-05-13 17:04:38.000' AS DateTime))
INSERT [dbo].[audittab] ([userid], [action1], [period]) VALUES (N'ADMIN          ', N'Insert new record for Pay Item code: P1087 In Payitems Setup                                                                                                                                            ', CAST(N'2016-05-13 17:05:14.000' AS DateTime))
INSERT [dbo].[audittab] ([userid], [action1], [period]) VALUES (N'ADMIN          ', N'Insert new record for Pay Item code: P1088 In Payitems Setup                                                                                                                                            ', CAST(N'2016-05-13 17:06:22.000' AS DateTime))
INSERT [dbo].[audittab] ([userid], [action1], [period]) VALUES (N'ADMIN          ', N'Insert new record for Staffid : UH006 In Staff Information                                                                                                                                              ', CAST(N'2016-05-13 12:45:07.000' AS DateTime))
INSERT [dbo].[audittab] ([userid], [action1], [period]) VALUES (N'UH004          ', N'Login into the system                                                                                                                                                                                   ', CAST(N'2016-05-13 14:00:07.000' AS DateTime))
INSERT [dbo].[audittab] ([userid], [action1], [period]) VALUES (N'ADMIN          ', N'Login into the system                                                                                                                                                                                   ', CAST(N'2016-05-13 14:37:40.000' AS DateTime))
INSERT [dbo].[audittab] ([userid], [action1], [period]) VALUES (N'ADMIN          ', N'Update account of User id : UH005                                                                                                                                                                       ', CAST(N'2016-05-13 14:38:26.000' AS DateTime))
INSERT [dbo].[audittab] ([userid], [action1], [period]) VALUES (N'ADMIN          ', N'Login into the system                                                                                                                                                                                   ', CAST(N'2016-05-13 15:46:53.000' AS DateTime))
INSERT [dbo].[audittab] ([userid], [action1], [period]) VALUES (N'ADMIN          ', N'Insert new record for Pay Item code: P1080 In Payitems Setup                                                                                                                                            ', CAST(N'2016-05-13 16:58:59.000' AS DateTime))
INSERT [dbo].[audittab] ([userid], [action1], [period]) VALUES (N'ADMIN          ', N'Insert new record for Pay Item code: P1081 In Payitems Setup                                                                                                                                            ', CAST(N'2016-05-13 16:59:22.000' AS DateTime))
INSERT [dbo].[audittab] ([userid], [action1], [period]) VALUES (N'ADMIN          ', N'Insert new record for Pay Item code: P1083 In Payitems Setup                                                                                                                                            ', CAST(N'2016-05-13 16:59:50.000' AS DateTime))
INSERT [dbo].[audittab] ([userid], [action1], [period]) VALUES (N'ADMIN          ', N'Insert new record for Pay Item code: P1084 In Payitems Setup                                                                                                                                            ', CAST(N'2016-05-13 17:00:12.000' AS DateTime))
INSERT [dbo].[BANKSETUP] ([BANKCODE], [sortcode], [NAMES], [BRANCH], [CMANAGER1], [address]) VALUES (N'18000               ', N'3243', N'ZENITH BANK INTERNATIONAL                                                                                               ', NULL, NULL, NULL)
INSERT [dbo].[BANKSETUP] ([BANKCODE], [sortcode], [NAMES], [BRANCH], [CMANAGER1], [address]) VALUES (N'18001               ', N'2335   ', N'KEYSTONE BANK                                                                                                           ', NULL, NULL, NULL)
INSERT [dbo].[BANKSETUP] ([BANKCODE], [sortcode], [NAMES], [BRANCH], [CMANAGER1], [address]) VALUES (N'18002               ', N'22', N'UNITED BANK FOR AFRICA PLC                                                                                   ', N' IKEJA                                                                          ', NULL, NULL)
INSERT [dbo].[BANKSETUP] ([BANKCODE], [sortcode], [NAMES], [BRANCH], [CMANAGER1], [address]) VALUES (N'18003               ', N'33', N'UNITED BANK FOR AFRICA PLC                                                                                          ', N' (PH)                                                                           ', NULL, NULL)
INSERT [dbo].[BANKSETUP] ([BANKCODE], [sortcode], [NAMES], [BRANCH], [CMANAGER1], [address]) VALUES (N'18005               ', N'44', N'UNITED BANK FOR AFRICA PLC                                                                                     ', N'(WARRI)                                                                         ', NULL, NULL)
INSERT [dbo].[BANKSETUP] ([BANKCODE], [sortcode], [NAMES], [BRANCH], [CMANAGER1], [address]) VALUES (N'18006               ', N'55', N'UNION BANK OF NIGERIA PLC                                                                                               ', NULL, NULL, NULL)
INSERT [dbo].[BANKSETUP] ([BANKCODE], [sortcode], [NAMES], [BRANCH], [CMANAGER1], [address]) VALUES (N'18008               ', N'66', N'STANDARD CHARTERED BANK                                                                                                 ', NULL, NULL, NULL)
INSERT [dbo].[codestab] ([code1], [descr], [option1], [AMOUNT]) VALUES (N'ITMGT               ', N'IT MANAGER                                                                      ', N'F5   ', NULL)
INSERT [dbo].[codestab] ([code1], [descr], [option1], [AMOUNT]) VALUES (N'1101                ', N'MALARIA                                                                         ', N'F15  ', NULL)
INSERT [dbo].[codestab] ([code1], [descr], [option1], [AMOUNT]) VALUES (N'RLT                 ', N'RELATIONSHIP DEPT                                                               ', N'F3   ', NULL)
INSERT [dbo].[codestab] ([code1], [descr], [option1], [AMOUNT]) VALUES (N'SALES               ', N'SALES/MARKETING DEPT                                                            ', N'F3   ', NULL)
INSERT [dbo].[codestab] ([code1], [descr], [option1], [AMOUNT]) VALUES (N'S10                 ', N'LAGOS                                                                           ', N'F1   ', NULL)
INSERT [dbo].[codestab] ([code1], [descr], [option1], [AMOUNT]) VALUES (N'SALESMGT            ', N'SALES MANAGER                                                                   ', N'F5   ', NULL)
INSERT [dbo].[codestab] ([code1], [descr], [option1], [AMOUNT]) VALUES (N'RLTMGT              ', N'RELATIONSHIP MANAGER                                                            ', N'F5   ', NULL)
INSERT [dbo].[codestab] ([code1], [descr], [option1], [AMOUNT]) VALUES (N'ADMINMGT            ', N'ADMIN MANAGER                                                                   ', N'F5   ', NULL)
INSERT [dbo].[codestab] ([code1], [descr], [option1], [AMOUNT]) VALUES (N'010                 ', N'TRADING INCOME                                                                  ', N'F26  ', NULL)
INSERT [dbo].[codestab] ([code1], [descr], [option1], [AMOUNT]) VALUES (N'009                 ', N'ACCUMULATED PROFIT                                                              ', N'F26  ', NULL)
INSERT [dbo].[codestab] ([code1], [descr], [option1], [AMOUNT]) VALUES (N'HP001               ', N'CLASSIC                                                                         ', NULL, CAST(7500.00 AS Numeric(18, 2)))
INSERT [dbo].[codestab] ([code1], [descr], [option1], [AMOUNT]) VALUES (N'101                 ', N'FIXED ASSERT                                                                    ', N'F16  ', NULL)
INSERT [dbo].[codestab] ([code1], [descr], [option1], [AMOUNT]) VALUES (N'102                 ', N'INCOME                                                                          ', N'F16  ', NULL)
INSERT [dbo].[codestab] ([code1], [descr], [option1], [AMOUNT]) VALUES (N'MD                  ', N'MANAGING DIREDCTOR                                                              ', N'F5   ', NULL)
INSERT [dbo].[codestab] ([code1], [descr], [option1], [AMOUNT]) VALUES (N'PUBSEC              ', N'PUBLIC SECTOR (NHIS)                                                            ', N'F12  ', NULL)
INSERT [dbo].[codestab] ([code1], [descr], [option1], [AMOUNT]) VALUES (N'PRIVASEC            ', N'ORGANISED PRIVATE SECTOR                                                        ', N'F12  ', NULL)
INSERT [dbo].[codestab] ([code1], [descr], [option1], [AMOUNT]) VALUES (N'PUBNET              ', N'PUBLIC PROVIDER HOSPITAL                                                        ', N'F14  ', NULL)
INSERT [dbo].[codestab] ([code1], [descr], [option1], [AMOUNT]) VALUES (N'PRIVANET            ', N'PRIVATE PROVIDER HOSPITAL                                                       ', N'F14  ', NULL)
INSERT [dbo].[codestab] ([code1], [descr], [option1], [AMOUNT]) VALUES (N'54                  ', N'ABIA SOUTH                                                                      ', N'F2   ', NULL)
INSERT [dbo].[codestab] ([code1], [descr], [option1], [AMOUNT]) VALUES (N'60                  ', N'SURULERE LGA                                                                    ', N'F2   ', NULL)
INSERT [dbo].[codestab] ([code1], [descr], [option1], [AMOUNT]) VALUES (N'10                  ', N'Spouse                                                                          ', N'GG   ', NULL)
INSERT [dbo].[codestab] ([code1], [descr], [option1], [AMOUNT]) VALUES (N'20                  ', N'Child (1)                                                                       ', N'GG   ', NULL)
INSERT [dbo].[codestab] ([code1], [descr], [option1], [AMOUNT]) VALUES (N'30                  ', N'Child (2)                                                                       ', N'GG   ', NULL)
INSERT [dbo].[codestab] ([code1], [descr], [option1], [AMOUNT]) VALUES (N'40                  ', N'Child (3)                                                                       ', N'GG   ', NULL)
INSERT [dbo].[codestab] ([code1], [descr], [option1], [AMOUNT]) VALUES (N'50                  ', N'Child (4)                                                                       ', N'GG   ', NULL)
INSERT [dbo].[codestab] ([code1], [descr], [option1], [AMOUNT]) VALUES (N'52                  ', N'LAGOS PFA                                                                       ', N'F9   ', NULL)
INSERT [dbo].[codestab] ([code1], [descr], [option1], [AMOUNT]) VALUES (N'BRAN10              ', N'SURULERE LAGOS                                                                  ', N'F6   ', NULL)
INSERT [dbo].[codestab] ([code1], [descr], [option1], [AMOUNT]) VALUES (N'GL01                ', N'GRADE LEVEL 01                                                                  ', N'F4   ', NULL)
INSERT [dbo].[codestab] ([code1], [descr], [option1], [AMOUNT]) VALUES (N'USA                 ', N'USA                                                                             ', N'F11  ', NULL)
INSERT [dbo].[codestab] ([code1], [descr], [option1], [AMOUNT]) VALUES (N'603                 ', N'SALES POINT 2                                                                   ', N'F3   ', NULL)
INSERT [dbo].[codestab] ([code1], [descr], [option1], [AMOUNT]) VALUES (N'SR                  ', N'SENIOR STAFF                                                                    ', N'F8   ', NULL)
INSERT [dbo].[codestab] ([code1], [descr], [option1], [AMOUNT]) VALUES (N'JR                  ', N'JUNIOR STAFF                                                                    ', N'F8   ', NULL)
INSERT [dbo].[codestab] ([code1], [descr], [option1], [AMOUNT]) VALUES (N'MGT                 ', N'MANAGEMENT                                                                      ', N'F8   ', NULL)
INSERT [dbo].[codestab] ([code1], [descr], [option1], [AMOUNT]) VALUES (N'006                 ', N'CURRENT LIABILITY                                                               ', N'F26  ', NULL)
INSERT [dbo].[codestab] ([code1], [descr], [option1], [AMOUNT]) VALUES (N'007                 ', N'LONG TERM LIABILITY                                                             ', N'F26  ', NULL)
INSERT [dbo].[codestab] ([code1], [descr], [option1], [AMOUNT]) VALUES (N'008                 ', N'CAPITAL                                                                         ', N'F26  ', NULL)
INSERT [dbo].[codestab] ([code1], [descr], [option1], [AMOUNT]) VALUES (N'001                 ', N'FIXED ASSET                                                                     ', N'F26  ', NULL)
INSERT [dbo].[codestab] ([code1], [descr], [option1], [AMOUNT]) VALUES (N'002                 ', N'INVESTMENTS                                                                     ', N'F26  ', NULL)
INSERT [dbo].[codestab] ([code1], [descr], [option1], [AMOUNT]) VALUES (N'014                 ', N'INVENTORY                                                                       ', N'F26  ', NULL)
INSERT [dbo].[codestab] ([code1], [descr], [option1], [AMOUNT]) VALUES (N'003                 ', N'ACCOUNTS RECEIVABLE                                                             ', N'F26  ', NULL)
INSERT [dbo].[codestab] ([code1], [descr], [option1], [AMOUNT]) VALUES (N'005                 ', N'BANK                                                                            ', N'F26  ', NULL)
INSERT [dbo].[codestab] ([code1], [descr], [option1], [AMOUNT]) VALUES (N'011                 ', N'INCOME                                                                          ', N'F26  ', NULL)
INSERT [dbo].[codestab] ([code1], [descr], [option1], [AMOUNT]) VALUES (N'012                 ', N'TRADING EXPENSE                                                                 ', N'F26  ', NULL)
INSERT [dbo].[codestab] ([code1], [descr], [option1], [AMOUNT]) VALUES (N'013                 ', N'EXPENSE                                                                         ', N'F26  ', NULL)
INSERT [dbo].[codestab] ([code1], [descr], [option1], [AMOUNT]) VALUES (N'004                 ', N'CURRENT ASSERT                                                                  ', N'F26  ', NULL)
INSERT [dbo].[codestab] ([code1], [descr], [option1], [AMOUNT]) VALUES (N'36                  ', N'Zafara                                                                          ', N'F1   ', NULL)
INSERT [dbo].[codestab] ([code1], [descr], [option1], [AMOUNT]) VALUES (N'16                  ', N'Imo                                                                             ', N'F1   ', NULL)
INSERT [dbo].[codestab] ([code1], [descr], [option1], [AMOUNT]) VALUES (N'29                  ', N'Osun                                                                            ', N'F1   ', NULL)
INSERT [dbo].[codestab] ([code1], [descr], [option1], [AMOUNT]) VALUES (N'20                  ', N'Kastina                                                                         ', N'F1   ', NULL)
INSERT [dbo].[codestab] ([code1], [descr], [option1], [AMOUNT]) VALUES (N'03                  ', N'Akwa-Ibom                                                                       ', N'F1   ', NULL)
INSERT [dbo].[codestab] ([code1], [descr], [option1], [AMOUNT]) VALUES (N'23                  ', N'Kwara                                                                           ', N'F1   ', NULL)
INSERT [dbo].[codestab] ([code1], [descr], [option1], [AMOUNT]) VALUES (N'25                  ', N'Nasarawa                                                                        ', N'F1   ', NULL)
INSERT [dbo].[codestab] ([code1], [descr], [option1], [AMOUNT]) VALUES (N'17                  ', N'Jigawa                                                                          ', N'F1   ', NULL)
INSERT [dbo].[codestab] ([code1], [descr], [option1], [AMOUNT]) VALUES (N'38                  ', N'AKWA-IBOM                                                                       ', N'F1   ', NULL)
INSERT [dbo].[codestab] ([code1], [descr], [option1], [AMOUNT]) VALUES (N'13                  ', N'Ekiti                                                                           ', N'F1   ', NULL)
INSERT [dbo].[codestab] ([code1], [descr], [option1], [AMOUNT]) VALUES (N'12                  ', N'Edo                                                                             ', N'F1   ', NULL)
INSERT [dbo].[codestab] ([code1], [descr], [option1], [AMOUNT]) VALUES (N'05                  ', N'Bauchi                                                                          ', N'F1   ', NULL)
INSERT [dbo].[codestab] ([code1], [descr], [option1], [AMOUNT]) VALUES (N'15                  ', N'Gombe                                                                           ', N'F1   ', NULL)
INSERT [dbo].[codestab] ([code1], [descr], [option1], [AMOUNT]) VALUES (N'21                  ', N'Kebbi                                                                           ', N'F1   ', NULL)
INSERT [dbo].[codestab] ([code1], [descr], [option1], [AMOUNT]) VALUES (N'26                  ', N'Niger                                                                           ', N'F1   ', NULL)
INSERT [dbo].[codestab] ([code1], [descr], [option1], [AMOUNT]) VALUES (N'28                  ', N'Ondo                                                                            ', N'F1   ', NULL)
INSERT [dbo].[codestab] ([code1], [descr], [option1], [AMOUNT]) VALUES (N'31                  ', N'Plateau                                                                         ', N'F1   ', NULL)
INSERT [dbo].[codestab] ([code1], [descr], [option1], [AMOUNT]) VALUES (N'06                  ', N'Bayelsa                                                                         ', N'F1   ', NULL)
INSERT [dbo].[codestab] ([code1], [descr], [option1], [AMOUNT]) VALUES (N'30                  ', N'Oyo                                                                             ', N'F1   ', NULL)
INSERT [dbo].[codestab] ([code1], [descr], [option1], [AMOUNT]) VALUES (N'02                  ', N'Adamawa                                                                         ', N'F1   ', NULL)
INSERT [dbo].[codestab] ([code1], [descr], [option1], [AMOUNT]) VALUES (N'08                  ', N'Borno                                                                           ', N'F1   ', NULL)
INSERT [dbo].[codestab] ([code1], [descr], [option1], [AMOUNT]) VALUES (N'32                  ', N'Rivers                                                                          ', N'F1   ', NULL)
INSERT [dbo].[codestab] ([code1], [descr], [option1], [AMOUNT]) VALUES (N'27                  ', N'Ogun                                                                            ', N'F1   ', NULL)
INSERT [dbo].[codestab] ([code1], [descr], [option1], [AMOUNT]) VALUES (N'01                  ', N'Abia                                                                            ', N'F1   ', NULL)
INSERT [dbo].[codestab] ([code1], [descr], [option1], [AMOUNT]) VALUES (N'11                  ', N'Ebonyi                                                                          ', N'F1   ', NULL)
INSERT [dbo].[codestab] ([code1], [descr], [option1], [AMOUNT]) VALUES (N'07                  ', N'Benue                                                                           ', N'F1   ', NULL)
INSERT [dbo].[codestab] ([code1], [descr], [option1], [AMOUNT]) VALUES (N'18                  ', N'Kaduna                                                                          ', N'F1   ', NULL)
INSERT [dbo].[codestab] ([code1], [descr], [option1], [AMOUNT]) VALUES (N'34                  ', N'Taraba                                                                          ', N'F1   ', NULL)
INSERT [dbo].[codestab] ([code1], [descr], [option1], [AMOUNT]) VALUES (N'33                  ', N'Sokoto                                                                          ', N'F1   ', NULL)
INSERT [dbo].[codestab] ([code1], [descr], [option1], [AMOUNT]) VALUES (N'S10                 ', N'Lagos                                                                           ', N'F1   ', NULL)
INSERT [dbo].[codestab] ([code1], [descr], [option1], [AMOUNT]) VALUES (N'04                  ', N'Anambra                                                                         ', N'F1   ', NULL)
INSERT [dbo].[codestab] ([code1], [descr], [option1], [AMOUNT]) VALUES (N'19                  ', N'Kano                                                                            ', N'F1   ', NULL)
INSERT [dbo].[codestab] ([code1], [descr], [option1], [AMOUNT]) VALUES (N'09                  ', N'Cross River                                                                     ', N'F1   ', NULL)
INSERT [dbo].[codestab] ([code1], [descr], [option1], [AMOUNT]) VALUES (N'35                  ', N'Yobe                                                                            ', N'F1   ', NULL)
INSERT [dbo].[codestab] ([code1], [descr], [option1], [AMOUNT]) VALUES (N'S20                 ', N'FCT                                                                             ', N'F1   ', NULL)
INSERT [dbo].[codestab] ([code1], [descr], [option1], [AMOUNT]) VALUES (N'14                  ', N'Enugu                                                                           ', N'F1   ', NULL)
INSERT [dbo].[codestab] ([code1], [descr], [option1], [AMOUNT]) VALUES (N'22                  ', N'Kogi                                                                            ', N'F1   ', NULL)
INSERT [dbo].[codestab] ([code1], [descr], [option1], [AMOUNT]) VALUES (N'10                  ', N'Delta                                                                           ', N'F1   ', NULL)
INSERT [dbo].[codestab] ([code1], [descr], [option1], [AMOUNT]) VALUES (N'STABIC              ', N'STABIC IBTC                                                                     ', N'F9   ', NULL)
INSERT [dbo].[codestab] ([code1], [descr], [option1], [AMOUNT]) VALUES (N'10                  ', N'TANGIBLE ASSERT                                                                 ', N'F10  ', NULL)
INSERT [dbo].[codestab] ([code1], [descr], [option1], [AMOUNT]) VALUES (N'20                  ', N'INTANGIBLE ASSERT                                                               ', N'F10  ', NULL)
INSERT [dbo].[codestab] ([code1], [descr], [option1], [AMOUNT]) VALUES (N'10                  ', N'ANNUAL LEAVE                                                                    ', N'L31  ', NULL)
INSERT [dbo].[codestab] ([code1], [descr], [option1], [AMOUNT]) VALUES (N'20                  ', N'SICK LEAVE                                                                      ', N'L31  ', NULL)
INSERT [dbo].[codestab] ([code1], [descr], [option1], [AMOUNT]) VALUES (N'30                  ', N'EXAM LEAVE                                                                      ', N'L31  ', NULL)
INSERT [dbo].[codestab] ([code1], [descr], [option1], [AMOUNT]) VALUES (N'40                  ', N'MATERNITY LEAVE                                                                 ', N'L31  ', NULL)
INSERT [dbo].[codestab] ([code1], [descr], [option1], [AMOUNT]) VALUES (N'50                  ', N'CASUAL LEAVE                                                                    ', N'L31  ', NULL)
INSERT [dbo].[codestab] ([code1], [descr], [option1], [AMOUNT]) VALUES (N'MED                 ', N'MEDICAL DEPT                                                                    ', N'F3   ', NULL)
INSERT [dbo].[codestab] ([code1], [descr], [option1], [AMOUNT]) VALUES (N'ACCT                ', N'ACCOUNT                                                                         ', N'F3   ', NULL)
INSERT [dbo].[codestab] ([code1], [descr], [option1], [AMOUNT]) VALUES (N'ITC                 ', N'IT DEPARTMENT                                                                   ', N'F3   ', NULL)
INSERT [dbo].[codestab] ([code1], [descr], [option1], [AMOUNT]) VALUES (N'ADMIN               ', N'ADMIN/PERSONNEL  DEPARTMENT                                                     ', N'F3   ', NULL)
INSERT [dbo].[codestab] ([code1], [descr], [option1], [AMOUNT]) VALUES (N'FRNTMGT             ', N'FRONT DESCK MGT                                                                 ', N'F5   ', NULL)
INSERT [dbo].[codestab] ([code1], [descr], [option1], [AMOUNT]) VALUES (N'30                  ', N'INFORMAL SECTOR                                                                 ', N'F12  ', NULL)
INSERT [dbo].[companytab] ([code1], [company], [address], [address2], [tel], [web], [email], [picpath], [backgroundimg]) VALUES (N'061       ', N'ULTIMATE HEALTH MANAGEMENT SERVICES LTD                                                                                                                                                                 ', N'Tsukunda House, 1446, Constitution Avenue, Airport Return                                                                                                                                               ', N'Road, Central Business District, Abuja FCT.                                                                                                                                                             ', N'08111111448, 08030951853, 07033919722, 08055908719 & 09-8702839                                                                                                                                         ', N'http://www.ultimatehealthhmo.com/                                                         ', N'info@ultimatehealthhmo.com                                                                                                                                                                              ', N'C:\dsnlHMOsystems\dsnlHMOsystems\dsnlHMOsystems\Images\companylogo.jpg                                                                                                                                  ', N'C:\dsnlHMOsystems\dsnlHMOsystems\dsnlHMOsystems\Images\BKIMAGE1.jpg                                                                                                                                     ')
INSERT [dbo].[CURTAB] ([CURCODE], [CURNAME], [RATEN], [RATEDATE], [SYMBOL]) VALUES (N'NGR       ', N'NAIRA               ', CAST(1.0000 AS Numeric(9, 4)), CAST(N'2016-01-06 00:00:00.000' AS DateTime), N'=N=  ')
INSERT [dbo].[CURTAB] ([CURCODE], [CURNAME], [RATEN], [RATEDATE], [SYMBOL]) VALUES (N'DOLL      ', N'DOLLAR              ', CAST(240.0000 AS Numeric(9, 4)), CAST(N'2016-01-06 00:00:00.000' AS DateTime), N'$    ')
INSERT [dbo].[CURTAB] ([CURCODE], [CURNAME], [RATEN], [RATEDATE], [SYMBOL]) VALUES (N'POD       ', N'BRITISH POUND       ', CAST(280.0000 AS Numeric(9, 4)), CAST(N'2016-01-06 00:00:00.000' AS DateTime), N'&    ')
INSERT [dbo].[custvendtab] ([custvendid], [Names], [custvendtype], [cvtype], [address], [lga], [dreg], [website], [email], [spersontel], [sperson], [state], [country], [bankid], [scode], [bbranch], [acctid], [accttype], [glcode], [cbalance], [customersince]) VALUES (N'NHIS           ', N'NHIS NIGERIA                                                                                                            ', N'C  ', NULL, N'                                                                                                                                                                                    ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[digitsettings] ([bcodedidgit], [autocode], [companyid], [claimbatchcode], [rptpath], [photopath], [docfolder], [imgaepath], [invoicepaytrig], [enrolleexptrig], [paymentapprovaltrig], [birthdaytrig], [cursymbol], [deprciatn], [invoiceno], [accountname], [bankname], [branch], [accountno], [sortno], [autorecieptno], [paytcode], [payref], [portallink], [appraisalref], [leavref]) VALUES (CAST(5 AS Numeric(25, 0)), N' 10000023                     ', N'061            ', N'500032                        ', N'C:\dsnlHMOsystems\dsnlHMOsystems\dsnlHMOsystems\Reports                                                                                                                             ', N'C:\dsnlHMOsystems\Photo                                                                                                                                                             ', N'C:\dsnldoc                                                                                                                                                                          ', N'C:\dsnlHMOsystems\dsnlHMOsystems\dsnlHMOsystems\Images                                                                                                                              ', CAST(3 AS Numeric(5, 0)), CAST(30 AS Numeric(5, 0)), CAST(3 AS Numeric(5, 0)), CAST(3 AS Numeric(5, 0)), N'=N=', N'DPY', N'100005                        ', N'Ultimate Health Management Services Ltd                                            ', N'United Bank of Africa BankPlc                        ', N'Wuse II Branch, Abuja                      ', N'1017058396   ', N'033080013    ', N'3                             ', N'300003                        ', N'2                             ', N'http://www.ultimatehealthngportal.com/                                                              ', N'60005                         ', N'70010                         ')
INSERT [dbo].[enrolleetabimp] ([enrolleeid], [Surname], [Firstname], [othernames], [sex], [Maritalstatus], [title], [haddress], [age], [dofb], [tel], [email], [dregister], [sdate], [edate], [active], [nationalid], [NHIS], [ogaid], [ogaloc], [hcpid], [hcpname], [hcpaddress], [hcplga], [sectortype], [hplan], [pnetwork], [ugplan], [ugmfees], [ugyfees], [ugstodate], [ugbalance], [drelated], [extra], [recexist]) VALUES (N'bado11         ', N'fsfbs                         ', N'goooo                         ', N'tooo                                    ', N'dooo      ', N'Married   ', N'Mr        ', N'Lagos                                                                                                                                                                                                   ', N'25  ', CAST(N'2016-02-02 00:00:00.000' AS DateTime), N'8055485456                                                                                          ', N'defae                                                                                               ', CAST(N'2016-06-05 00:00:00.000' AS DateTime), CAST(N'2016-02-01 00:00:00.000' AS DateTime), CAST(N'2016-03-02 00:00:00.000' AS DateTime), 0, NULL, NULL, N'20001          ', NULL, N'30005          ', NULL, NULL, NULL, NULL, NULL, NULL, N'ugplan2        ', CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0 AS Decimal(3, 0)), CAST(0 AS Decimal(3, 0)), NULL)
INSERT [dbo].[enrolleetabimp] ([enrolleeid], [Surname], [Firstname], [othernames], [sex], [Maritalstatus], [title], [haddress], [age], [dofb], [tel], [email], [dregister], [sdate], [edate], [active], [nationalid], [NHIS], [ogaid], [ogaloc], [hcpid], [hcpname], [hcpaddress], [hcplga], [sectortype], [hplan], [pnetwork], [ugplan], [ugmfees], [ugyfees], [ugstodate], [ugbalance], [drelated], [extra], [recexist]) VALUES (N'bado12         ', N'fsfbs                         ', N'goooo                         ', N'tooo                                    ', N'dooo      ', N'Married   ', N'Mr        ', N'Lagos                                                                                                                                                                                                   ', N'25  ', CAST(N'2016-02-03 00:00:00.000' AS DateTime), N'8055485456                                                                                          ', N'defae                                                                                               ', CAST(N'2016-06-06 00:00:00.000' AS DateTime), CAST(N'2016-02-02 00:00:00.000' AS DateTime), CAST(N'2016-03-03 00:00:00.000' AS DateTime), 0, NULL, NULL, N'20001          ', NULL, N'30005          ', NULL, NULL, NULL, NULL, NULL, NULL, N'ugplan2        ', CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0 AS Decimal(3, 0)), CAST(0 AS Decimal(3, 0)), NULL)
INSERT [dbo].[enrolleetabimp] ([enrolleeid], [Surname], [Firstname], [othernames], [sex], [Maritalstatus], [title], [haddress], [age], [dofb], [tel], [email], [dregister], [sdate], [edate], [active], [nationalid], [NHIS], [ogaid], [ogaloc], [hcpid], [hcpname], [hcpaddress], [hcplga], [sectortype], [hplan], [pnetwork], [ugplan], [ugmfees], [ugyfees], [ugstodate], [ugbalance], [drelated], [extra], [recexist]) VALUES (N'bado13         ', N'fsfbs                         ', N'goooo                         ', N'tooo                                    ', N'dooo      ', N'Married   ', N'Mr        ', N'Lagos                                                                                                                                                                                                   ', N'25  ', CAST(N'2016-02-04 00:00:00.000' AS DateTime), N'8055485456                                                                                          ', N'defae                                                                                               ', CAST(N'2016-06-07 00:00:00.000' AS DateTime), CAST(N'2016-02-03 00:00:00.000' AS DateTime), CAST(N'2016-03-04 00:00:00.000' AS DateTime), 0, NULL, NULL, N'20001          ', NULL, N'30005          ', NULL, NULL, NULL, NULL, NULL, NULL, N'ugplan2        ', CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0 AS Decimal(3, 0)), CAST(0 AS Decimal(3, 0)), NULL)
INSERT [dbo].[enrolleetabimp] ([enrolleeid], [Surname], [Firstname], [othernames], [sex], [Maritalstatus], [title], [haddress], [age], [dofb], [tel], [email], [dregister], [sdate], [edate], [active], [nationalid], [NHIS], [ogaid], [ogaloc], [hcpid], [hcpname], [hcpaddress], [hcplga], [sectortype], [hplan], [pnetwork], [ugplan], [ugmfees], [ugyfees], [ugstodate], [ugbalance], [drelated], [extra], [recexist]) VALUES (N'bado14         ', N'fsfbs                         ', N'goooo                         ', N'tooo                                    ', N'dooo      ', N'Married   ', N'Mr        ', N'Lagos                                                                                                                                                                                                   ', N'25  ', CAST(N'2016-02-05 00:00:00.000' AS DateTime), N'8055485456                                                                                          ', N'defae                                                                                               ', CAST(N'2016-06-08 00:00:00.000' AS DateTime), CAST(N'2016-02-04 00:00:00.000' AS DateTime), CAST(N'2016-03-05 00:00:00.000' AS DateTime), 0, NULL, NULL, N'20001          ', NULL, N'30005          ', NULL, NULL, NULL, NULL, NULL, NULL, N'ugplan2        ', CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0 AS Decimal(3, 0)), CAST(0 AS Decimal(3, 0)), NULL)
INSERT [dbo].[enrolleetabimp] ([enrolleeid], [Surname], [Firstname], [othernames], [sex], [Maritalstatus], [title], [haddress], [age], [dofb], [tel], [email], [dregister], [sdate], [edate], [active], [nationalid], [NHIS], [ogaid], [ogaloc], [hcpid], [hcpname], [hcpaddress], [hcplga], [sectortype], [hplan], [pnetwork], [ugplan], [ugmfees], [ugyfees], [ugstodate], [ugbalance], [drelated], [extra], [recexist]) VALUES (N'bado15         ', N'fsfbs                         ', N'goooo                         ', N'tooo                                    ', N'dooo      ', N'Married   ', N'Mr        ', N'Lagos                                                                                                                                                                                                   ', N'25  ', CAST(N'2016-02-06 00:00:00.000' AS DateTime), N'8055485456                                                                                          ', N'defae                                                                                               ', CAST(N'2016-06-09 00:00:00.000' AS DateTime), CAST(N'2016-02-05 00:00:00.000' AS DateTime), CAST(N'2016-03-06 00:00:00.000' AS DateTime), 0, NULL, NULL, N'20001          ', NULL, N'30005          ', NULL, NULL, NULL, NULL, NULL, NULL, N'ugplan2        ', CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0 AS Decimal(3, 0)), CAST(0 AS Decimal(3, 0)), NULL)
INSERT [dbo].[enrolleetabimp] ([enrolleeid], [Surname], [Firstname], [othernames], [sex], [Maritalstatus], [title], [haddress], [age], [dofb], [tel], [email], [dregister], [sdate], [edate], [active], [nationalid], [NHIS], [ogaid], [ogaloc], [hcpid], [hcpname], [hcpaddress], [hcplga], [sectortype], [hplan], [pnetwork], [ugplan], [ugmfees], [ugyfees], [ugstodate], [ugbalance], [drelated], [extra], [recexist]) VALUES (N'bado16         ', N'fsfbs                         ', N'goooo                         ', N'tooo                                    ', N'dooo      ', N'Married   ', N'Mr        ', N'Lagos                                                                                                                                                                                                   ', N'25  ', CAST(N'2016-02-07 00:00:00.000' AS DateTime), N'8055485456                                                                                          ', N'defae                                                                                               ', CAST(N'2016-06-10 00:00:00.000' AS DateTime), CAST(N'2016-02-06 00:00:00.000' AS DateTime), CAST(N'2016-03-07 00:00:00.000' AS DateTime), 0, NULL, NULL, N'20001          ', NULL, N'30005          ', NULL, NULL, NULL, NULL, NULL, NULL, N'ugplan2        ', CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0 AS Decimal(3, 0)), CAST(0 AS Decimal(3, 0)), NULL)
INSERT [dbo].[enrolleetabimp] ([enrolleeid], [Surname], [Firstname], [othernames], [sex], [Maritalstatus], [title], [haddress], [age], [dofb], [tel], [email], [dregister], [sdate], [edate], [active], [nationalid], [NHIS], [ogaid], [ogaloc], [hcpid], [hcpname], [hcpaddress], [hcplga], [sectortype], [hplan], [pnetwork], [ugplan], [ugmfees], [ugyfees], [ugstodate], [ugbalance], [drelated], [extra], [recexist]) VALUES (N'bado17         ', N'fsfbs                         ', N'goooo                         ', N'tooo                                    ', N'dooo      ', N'Married   ', N'Mr        ', N'Lagos                                                                                                                                                                                                   ', N'25  ', CAST(N'2016-02-08 00:00:00.000' AS DateTime), N'8055485456                                                                                          ', N'defae                                                                                               ', CAST(N'2016-06-11 00:00:00.000' AS DateTime), CAST(N'2016-02-07 00:00:00.000' AS DateTime), CAST(N'2016-03-08 00:00:00.000' AS DateTime), 0, NULL, NULL, N'20001          ', NULL, N'30005          ', NULL, NULL, NULL, NULL, NULL, NULL, N'ugplan2        ', CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0 AS Decimal(3, 0)), CAST(0 AS Decimal(3, 0)), NULL)
INSERT [dbo].[enrolleetabimp] ([enrolleeid], [Surname], [Firstname], [othernames], [sex], [Maritalstatus], [title], [haddress], [age], [dofb], [tel], [email], [dregister], [sdate], [edate], [active], [nationalid], [NHIS], [ogaid], [ogaloc], [hcpid], [hcpname], [hcpaddress], [hcplga], [sectortype], [hplan], [pnetwork], [ugplan], [ugmfees], [ugyfees], [ugstodate], [ugbalance], [drelated], [extra], [recexist]) VALUES (N'bado18         ', N'fsfbs                         ', N'goooo                         ', N'tooo                                    ', N'dooo      ', N'Married   ', N'Mr        ', N'Lagos                                                                                                                                                                                                   ', N'25  ', CAST(N'2016-02-09 00:00:00.000' AS DateTime), N'8055485456                                                                                          ', N'defae                                                                                               ', CAST(N'2016-06-12 00:00:00.000' AS DateTime), CAST(N'2016-02-08 00:00:00.000' AS DateTime), CAST(N'2016-03-09 00:00:00.000' AS DateTime), 0, NULL, NULL, N'20001          ', NULL, N'30005          ', NULL, NULL, NULL, NULL, NULL, NULL, N'ugplan2        ', CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0 AS Decimal(3, 0)), CAST(0 AS Decimal(3, 0)), NULL)
INSERT [dbo].[evalitem] ([appcode], [appdesc], [maxmark], [evadetail]) VALUES (N'AP1                 ', N'DRESS & GROOM                 ', CAST(5 AS Numeric(3, 0)), N'This is only applicable to national staff
                                                                                       ')
INSERT [dbo].[evalitem] ([appcode], [appdesc], [maxmark], [evadetail]) VALUES (N'LTS                 ', N'LATENESS TO WORK              ', CAST(5 AS Numeric(3, 0)), N'nly used for special people
                                                                                                     ')
INSERT [dbo].[evalitem] ([appcode], [appdesc], [maxmark], [evadetail]) VALUES (N'EFF                 ', N'EFFICIENCY LEVEL              ', CAST(5 AS Numeric(3, 0)), N'This is for Nigeria staff
                                                                                                       ')
INSERT [dbo].[evalitem] ([appcode], [appdesc], [maxmark], [evadetail]) VALUES (N'WAT                 ', N'WORK ATTITUDE                 ', CAST(5 AS Numeric(3, 0)), N'Applicable to all staff
                                                                                                         ')
INSERT [dbo].[evalitem] ([appcode], [appdesc], [maxmark], [evadetail]) VALUES (N'ATT                 ', N'ATTITUDE TO WORK              ', CAST(5 AS Numeric(3, 0)), N'The attitude to work is a function of how serious you take your job.
                                                            ')
INSERT [dbo].[evalitem] ([appcode], [appdesc], [maxmark], [evadetail]) VALUES (N'V                   ', N'JOB PERFORMANCE               ', CAST(5 AS Numeric(3, 0)), N'Performance retaing on the job should have up to 50 percent of all rating
                                                       ')
INSERT [dbo].[evalitem] ([appcode], [appdesc], [maxmark], [evadetail]) VALUES (N'REL                 ', N'RELATIONSHIP WITH OTHERS      ', CAST(5 AS Numeric(3, 0)), N'Employee relationship and general behaviour
                                                                                     ')
INSERT [dbo].[evalitem] ([appcode], [appdesc], [maxmark], [evadetail]) VALUES (N'RES                 ', N'RESPONSIBILITY LEVEL          ', CAST(5 AS Numeric(3, 0)), N'Does Employee accept responsibilities 
                                                                                          ')
INSERT [dbo].[menutable] ([menucode], [menuname], [available]) VALUES (N'M1        ', N'Company Setup                                                                                                           ', 0)
INSERT [dbo].[menutable] ([menucode], [menuname], [available]) VALUES (N'M2        ', N'General Setup                                                                                                           ', 0)
INSERT [dbo].[menutable] ([menucode], [menuname], [available]) VALUES (N'M3        ', N'Online Backup/Restore                                                                                                   ', 0)
INSERT [dbo].[menutable] ([menucode], [menuname], [available]) VALUES (N'M4        ', N'Enrollment information                                                                                                  ', 0)
INSERT [dbo].[menutable] ([menucode], [menuname], [available]) VALUES (N'M5        ', N'Organization information                                                                                                ', 0)
INSERT [dbo].[menutable] ([menucode], [menuname], [available]) VALUES (N'M6        ', N'Hospital Information                                                                                                    ', 0)
INSERT [dbo].[menutable] ([menucode], [menuname], [available]) VALUES (N'M7        ', N'HCP Payment Register/Vetting                                                                                            ', 0)
INSERT [dbo].[menutable] ([menucode], [menuname], [available]) VALUES (N'M8        ', N'Payment Approvals / History                                                                                             ', 0)
INSERT [dbo].[menutable] ([menucode], [menuname], [available]) VALUES (N'M10       ', N'Staff Information                                                                                                       ', 0)
INSERT [dbo].[menutable] ([menucode], [menuname], [available]) VALUES (N'M9        ', N'Treatment Authorization                                                                                                 ', 0)
INSERT [dbo].[menutable] ([menucode], [menuname], [available]) VALUES (N'M11       ', N'Job Appraisal                                                                                                           ', 0)
INSERT [dbo].[menutable] ([menucode], [menuname], [available]) VALUES (N'M12       ', N'Leave Management                                                                                                        ', 0)
INSERT [dbo].[menutable] ([menucode], [menuname], [available]) VALUES (N'M13       ', N'Staff Birthday                                                                                                          ', 0)
INSERT [dbo].[menutable] ([menucode], [menuname], [available]) VALUES (N'M14       ', N'Account Main Menu                                                                                                       ', 0)
INSERT [dbo].[menutable] ([menucode], [menuname], [available]) VALUES (N'M15       ', N'Chart of Accounts                                                                                                       ', 0)
INSERT [dbo].[menutable] ([menucode], [menuname], [available]) VALUES (N'M16       ', N'Accounting Period Setup                                                                                                 ', 0)
INSERT [dbo].[menutable] ([menucode], [menuname], [available]) VALUES (N'M17       ', N'Opening Balance                                                                                                         ', 0)
INSERT [dbo].[menutable] ([menucode], [menuname], [available]) VALUES (N'M18       ', N'Bank Setup                                                                                                              ', 0)
INSERT [dbo].[menutable] ([menucode], [menuname], [available]) VALUES (N'M19       ', N'Account Group Setup                                                                                                     ', 0)
INSERT [dbo].[menutable] ([menucode], [menuname], [available]) VALUES (N'M20       ', N'Payroll Process                                                                                                         ', 0)
INSERT [dbo].[menutable] ([menucode], [menuname], [available]) VALUES (N'M21       ', N'Fixed Asset                                                                                                             ', 0)
INSERT [dbo].[menutable] ([menucode], [menuname], [available]) VALUES (N'M22       ', N'Receivable/Debtors Module                                                                                               ', 0)
INSERT [dbo].[menutable] ([menucode], [menuname], [available]) VALUES (N'M23       ', N'Payable/Creditors Module                                                                                                ', 0)
INSERT [dbo].[menutable] ([menucode], [menuname], [available]) VALUES (N'M25       ', N'General Ledger Module                                                                                                   ', 0)
INSERT [dbo].[menutable] ([menucode], [menuname], [available]) VALUES (N'M26       ', N'Detail Report Dailog                                                                                                    ', 0)
INSERT [dbo].[menutable] ([menucode], [menuname], [available]) VALUES (N'M27       ', N'List Reports                                                                                                            ', 0)
INSERT [dbo].[menutable] ([menucode], [menuname], [available]) VALUES (N'M28       ', N'General Settings                                                                                                        ', 0)
INSERT [dbo].[menutable] ([menucode], [menuname], [available]) VALUES (N'M29       ', N'User Account Management                                                                                                 ', 0)
INSERT [dbo].[menutable] ([menucode], [menuname], [available]) VALUES (N'M30       ', N'Audit Trail Settings                                                                                                    ', 0)
INSERT [dbo].[menutable] ([menucode], [menuname], [available]) VALUES (N'M31       ', N'Download/Upload Utility                                                                                                 ', 0)
INSERT [dbo].[menutable] ([menucode], [menuname], [available]) VALUES (N'M32       ', N'Generate Enrollee ID Card                                                                                               ', 0)
INSERT [dbo].[menutable] ([menucode], [menuname], [available]) VALUES (N'M33       ', N'Utilization fees                                                                                                        ', 0)
INSERT [dbo].[oganisationtab] ([ogaid], [oganames], [active], [dregister], [lga], [state], [country], [tel], [email], [website], [sperson], [address], [glcode], [bank], [bankbranch], [accountid], [sortcode], [sectortype], [hcpplan], [puprice], [punumber], [putotal], [pugrandtotal], [ugplan], [Utidefaultfees], [paidtodate]) VALUES (N'NHIS           ', N'NHIS NIGERIA                                                                                                                                          ', 0, CAST(N'2016-05-13 00:00:00.000' AS DateTime), N'54             ', N'S10            ', N'USA            ', N'                                                                                     ', N'                                                                                     ', N'                                                                                     ', N'                                                                                                                                                      ', N'                                                                                                                                                                                    ', N'               ', N'18000          ', N'                                                                                                                                                      ', N'                                                                                     ', N'                         ', N'PUBSEC         ', N'HP001          ', CAST(0.00 AS Numeric(18, 2)), CAST(0.00 AS Numeric(18, 2)), CAST(0.00 AS Numeric(18, 2)), CAST(0.00 AS Numeric(18, 2)), N'ugplan1        ', CAST(0.00 AS Numeric(18, 2)), CAST(0.00 AS Numeric(18, 2)))
INSERT [dbo].[payhst] ([staffid], [Names], [pic], [itemdescr], [pictype], [taxable], [scheme], [advance], [gradelvl], [deptcode], [bankid], [accountid], [pamount], [period], [paycaldate], [year], [month], [fixedtax], [totalallowance], [totaldeduction], [netpay]) VALUES (N'1005              ', N'JAMES THOMPSON SAMUEL                                                           ', N'P1004     ', N'MEDICAL ALLOWANCE                                 ', N'Allow     ', 1, 0, 0, N'GL01      ', N'601       ', N'18000     ', N'45454545  ', CAST(0.00 AS Numeric(15, 2)), CAST(5 AS Numeric(2, 0)), CAST(N'2016-05-08 19:47:28.000' AS DateTime), CAST(2016 AS Numeric(4, 0)), CAST(5 AS Numeric(2, 0)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)))
INSERT [dbo].[payhst] ([staffid], [Names], [pic], [itemdescr], [pictype], [taxable], [scheme], [advance], [gradelvl], [deptcode], [bankid], [accountid], [pamount], [period], [paycaldate], [year], [month], [fixedtax], [totalallowance], [totaldeduction], [netpay]) VALUES (N'1005              ', N'JAMES THOMPSON SAMUEL                                                           ', N'P1005     ', N'PENSION                                           ', N'Dedu      ', 0, 1, 0, N'GL01      ', N'601       ', N'18000     ', N'45454545  ', CAST(0.00 AS Numeric(15, 2)), CAST(5 AS Numeric(2, 0)), CAST(N'2016-05-08 19:47:28.000' AS DateTime), CAST(2016 AS Numeric(4, 0)), CAST(5 AS Numeric(2, 0)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)))
INSERT [dbo].[payhst] ([staffid], [Names], [pic], [itemdescr], [pictype], [taxable], [scheme], [advance], [gradelvl], [deptcode], [bankid], [accountid], [pamount], [period], [paycaldate], [year], [month], [fixedtax], [totalallowance], [totaldeduction], [netpay]) VALUES (N'1005              ', N'JAMES THOMPSON SAMUEL                                                           ', N'P1006     ', N'CAR LOAN                                          ', N'Dedu      ', 0, 0, 1, N'GL01      ', N'601       ', N'18000     ', N'45454545  ', CAST(0.00 AS Numeric(15, 2)), CAST(5 AS Numeric(2, 0)), CAST(N'2016-05-08 19:47:28.000' AS DateTime), CAST(2016 AS Numeric(4, 0)), CAST(5 AS Numeric(2, 0)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)))
INSERT [dbo].[payhst] ([staffid], [Names], [pic], [itemdescr], [pictype], [taxable], [scheme], [advance], [gradelvl], [deptcode], [bankid], [accountid], [pamount], [period], [paycaldate], [year], [month], [fixedtax], [totalallowance], [totaldeduction], [netpay]) VALUES (N'1005              ', N'JAMES THOMPSON SAMUEL                                                           ', N'P10076    ', N'RENT LOAN                                         ', N'Dedu      ', 0, 0, 1, N'GL01      ', N'601       ', N'18000     ', N'45454545  ', CAST(0.00 AS Numeric(15, 2)), CAST(5 AS Numeric(2, 0)), CAST(N'2016-05-08 19:47:28.000' AS DateTime), CAST(2016 AS Numeric(4, 0)), CAST(5 AS Numeric(2, 0)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)))
INSERT [dbo].[payhst] ([staffid], [Names], [pic], [itemdescr], [pictype], [taxable], [scheme], [advance], [gradelvl], [deptcode], [bankid], [accountid], [pamount], [period], [paycaldate], [year], [month], [fixedtax], [totalallowance], [totaldeduction], [netpay]) VALUES (N'1005              ', N'JAMES THOMPSON SAMUEL                                                           ', N'P1077     ', N'GRATUITY LOAN                                     ', N'Dedu      ', 0, 0, 1, N'GL01      ', N'601       ', N'18000     ', N'45454545  ', CAST(0.00 AS Numeric(15, 2)), CAST(5 AS Numeric(2, 0)), CAST(N'2016-05-08 19:47:28.000' AS DateTime), CAST(2016 AS Numeric(4, 0)), CAST(5 AS Numeric(2, 0)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)))
INSERT [dbo].[payhst] ([staffid], [Names], [pic], [itemdescr], [pictype], [taxable], [scheme], [advance], [gradelvl], [deptcode], [bankid], [accountid], [pamount], [period], [paycaldate], [year], [month], [fixedtax], [totalallowance], [totaldeduction], [netpay]) VALUES (N'1022              ', N'LOKOSO OMOBADA DAUDA                                                            ', N'P1001     ', N'BASIC SALARY                                      ', N'Basic     ', 1, 0, 0, N'GL01      ', N'601       ', N'18002     ', N'34534534  ', CAST(0.00 AS Numeric(15, 2)), CAST(5 AS Numeric(2, 0)), CAST(N'2016-05-08 19:47:28.000' AS DateTime), CAST(2016 AS Numeric(4, 0)), CAST(5 AS Numeric(2, 0)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)))
INSERT [dbo].[payhst] ([staffid], [Names], [pic], [itemdescr], [pictype], [taxable], [scheme], [advance], [gradelvl], [deptcode], [bankid], [accountid], [pamount], [period], [paycaldate], [year], [month], [fixedtax], [totalallowance], [totaldeduction], [netpay]) VALUES (N'1022              ', N'LOKOSO OMOBADA DAUDA                                                            ', N'P1002     ', N'TRANSPORT ALLOWANCE                               ', N'Allow     ', 1, 0, 0, N'GL01      ', N'601       ', N'18002     ', N'34534534  ', CAST(0.00 AS Numeric(15, 2)), CAST(5 AS Numeric(2, 0)), CAST(N'2016-05-08 19:47:28.000' AS DateTime), CAST(2016 AS Numeric(4, 0)), CAST(5 AS Numeric(2, 0)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)))
INSERT [dbo].[payhst] ([staffid], [Names], [pic], [itemdescr], [pictype], [taxable], [scheme], [advance], [gradelvl], [deptcode], [bankid], [accountid], [pamount], [period], [paycaldate], [year], [month], [fixedtax], [totalallowance], [totaldeduction], [netpay]) VALUES (N'1022              ', N'LOKOSO OMOBADA DAUDA                                                            ', N'P1003     ', N'HOUSING ALLOWANCE                                 ', N'Allow     ', 1, 0, 0, N'GL01      ', N'601       ', N'18002     ', N'34534534  ', CAST(0.00 AS Numeric(15, 2)), CAST(5 AS Numeric(2, 0)), CAST(N'2016-05-08 19:47:28.000' AS DateTime), CAST(2016 AS Numeric(4, 0)), CAST(5 AS Numeric(2, 0)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)))
INSERT [dbo].[payhst] ([staffid], [Names], [pic], [itemdescr], [pictype], [taxable], [scheme], [advance], [gradelvl], [deptcode], [bankid], [accountid], [pamount], [period], [paycaldate], [year], [month], [fixedtax], [totalallowance], [totaldeduction], [netpay]) VALUES (N'1022              ', N'LOKOSO OMOBADA DAUDA                                                            ', N'P1004     ', N'MEDICAL ALLOWANCE                                 ', N'Allow     ', 1, 0, 0, N'GL01      ', N'601       ', N'18002     ', N'34534534  ', CAST(0.00 AS Numeric(15, 2)), CAST(5 AS Numeric(2, 0)), CAST(N'2016-05-08 19:47:28.000' AS DateTime), CAST(2016 AS Numeric(4, 0)), CAST(5 AS Numeric(2, 0)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)))
INSERT [dbo].[payhst] ([staffid], [Names], [pic], [itemdescr], [pictype], [taxable], [scheme], [advance], [gradelvl], [deptcode], [bankid], [accountid], [pamount], [period], [paycaldate], [year], [month], [fixedtax], [totalallowance], [totaldeduction], [netpay]) VALUES (N'1022              ', N'LOKOSO OMOBADA DAUDA                                                            ', N'P1005     ', N'PENSION                                           ', N'Dedu      ', 0, 1, 0, N'GL01      ', N'601       ', N'18002     ', N'34534534  ', CAST(0.00 AS Numeric(15, 2)), CAST(5 AS Numeric(2, 0)), CAST(N'2016-05-08 19:47:28.000' AS DateTime), CAST(2016 AS Numeric(4, 0)), CAST(5 AS Numeric(2, 0)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)))
INSERT [dbo].[payhst] ([staffid], [Names], [pic], [itemdescr], [pictype], [taxable], [scheme], [advance], [gradelvl], [deptcode], [bankid], [accountid], [pamount], [period], [paycaldate], [year], [month], [fixedtax], [totalallowance], [totaldeduction], [netpay]) VALUES (N'1022              ', N'LOKOSO OMOBADA DAUDA                                                            ', N'P1006     ', N'CAR LOAN                                          ', N'Dedu      ', 0, 0, 1, N'GL01      ', N'601       ', N'18002     ', N'34534534  ', CAST(0.00 AS Numeric(15, 2)), CAST(5 AS Numeric(2, 0)), CAST(N'2016-05-08 19:47:28.000' AS DateTime), CAST(2016 AS Numeric(4, 0)), CAST(5 AS Numeric(2, 0)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)))
INSERT [dbo].[payhst] ([staffid], [Names], [pic], [itemdescr], [pictype], [taxable], [scheme], [advance], [gradelvl], [deptcode], [bankid], [accountid], [pamount], [period], [paycaldate], [year], [month], [fixedtax], [totalallowance], [totaldeduction], [netpay]) VALUES (N'1022              ', N'LOKOSO OMOBADA DAUDA                                                            ', N'P10076    ', N'RENT LOAN                                         ', N'Dedu      ', 0, 0, 1, N'GL01      ', N'601       ', N'18002     ', N'34534534  ', CAST(0.00 AS Numeric(15, 2)), CAST(5 AS Numeric(2, 0)), CAST(N'2016-05-08 19:47:28.000' AS DateTime), CAST(2016 AS Numeric(4, 0)), CAST(5 AS Numeric(2, 0)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)))
INSERT [dbo].[payhst] ([staffid], [Names], [pic], [itemdescr], [pictype], [taxable], [scheme], [advance], [gradelvl], [deptcode], [bankid], [accountid], [pamount], [period], [paycaldate], [year], [month], [fixedtax], [totalallowance], [totaldeduction], [netpay]) VALUES (N'1022              ', N'LOKOSO OMOBADA DAUDA                                                            ', N'P1077     ', N'GRATUITY LOAN                                     ', N'Dedu      ', 0, 0, 1, N'GL01      ', N'601       ', N'18002     ', N'34534534  ', CAST(0.00 AS Numeric(15, 2)), CAST(5 AS Numeric(2, 0)), CAST(N'2016-05-08 19:47:28.000' AS DateTime), CAST(2016 AS Numeric(4, 0)), CAST(5 AS Numeric(2, 0)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)))
INSERT [dbo].[payhst] ([staffid], [Names], [pic], [itemdescr], [pictype], [taxable], [scheme], [advance], [gradelvl], [deptcode], [bankid], [accountid], [pamount], [period], [paycaldate], [year], [month], [fixedtax], [totalallowance], [totaldeduction], [netpay]) VALUES (N'1023              ', N'JOJO KOKO TOTO                                                                  ', N'P1001     ', N'BASIC SALARY                                      ', N'Basic     ', 1, 0, 0, N'GL01      ', N'601       ', N'18000     ', N'346346346 ', CAST(0.00 AS Numeric(15, 2)), CAST(5 AS Numeric(2, 0)), CAST(N'2016-05-08 19:47:28.000' AS DateTime), CAST(2016 AS Numeric(4, 0)), CAST(5 AS Numeric(2, 0)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)))
INSERT [dbo].[payhst] ([staffid], [Names], [pic], [itemdescr], [pictype], [taxable], [scheme], [advance], [gradelvl], [deptcode], [bankid], [accountid], [pamount], [period], [paycaldate], [year], [month], [fixedtax], [totalallowance], [totaldeduction], [netpay]) VALUES (N'1023              ', N'JOJO KOKO TOTO                                                                  ', N'P1002     ', N'TRANSPORT ALLOWANCE                               ', N'Allow     ', 1, 0, 0, N'GL01      ', N'601       ', N'18000     ', N'346346346 ', CAST(0.00 AS Numeric(15, 2)), CAST(5 AS Numeric(2, 0)), CAST(N'2016-05-08 19:47:28.000' AS DateTime), CAST(2016 AS Numeric(4, 0)), CAST(5 AS Numeric(2, 0)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)))
INSERT [dbo].[payhst] ([staffid], [Names], [pic], [itemdescr], [pictype], [taxable], [scheme], [advance], [gradelvl], [deptcode], [bankid], [accountid], [pamount], [period], [paycaldate], [year], [month], [fixedtax], [totalallowance], [totaldeduction], [netpay]) VALUES (N'1023              ', N'JOJO KOKO TOTO                                                                  ', N'P1003     ', N'HOUSING ALLOWANCE                                 ', N'Allow     ', 1, 0, 0, N'GL01      ', N'601       ', N'18000     ', N'346346346 ', CAST(0.00 AS Numeric(15, 2)), CAST(5 AS Numeric(2, 0)), CAST(N'2016-05-08 19:47:28.000' AS DateTime), CAST(2016 AS Numeric(4, 0)), CAST(5 AS Numeric(2, 0)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)))
INSERT [dbo].[payhst] ([staffid], [Names], [pic], [itemdescr], [pictype], [taxable], [scheme], [advance], [gradelvl], [deptcode], [bankid], [accountid], [pamount], [period], [paycaldate], [year], [month], [fixedtax], [totalallowance], [totaldeduction], [netpay]) VALUES (N'1023              ', N'JOJO KOKO TOTO                                                                  ', N'P1004     ', N'MEDICAL ALLOWANCE                                 ', N'Allow     ', 1, 0, 0, N'GL01      ', N'601       ', N'18000     ', N'346346346 ', CAST(0.00 AS Numeric(15, 2)), CAST(5 AS Numeric(2, 0)), CAST(N'2016-05-08 19:47:28.000' AS DateTime), CAST(2016 AS Numeric(4, 0)), CAST(5 AS Numeric(2, 0)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)))
INSERT [dbo].[payhst] ([staffid], [Names], [pic], [itemdescr], [pictype], [taxable], [scheme], [advance], [gradelvl], [deptcode], [bankid], [accountid], [pamount], [period], [paycaldate], [year], [month], [fixedtax], [totalallowance], [totaldeduction], [netpay]) VALUES (N'1023              ', N'JOJO KOKO TOTO                                                                  ', N'P1005     ', N'PENSION                                           ', N'Dedu      ', 0, 1, 0, N'GL01      ', N'601       ', N'18000     ', N'346346346 ', CAST(0.00 AS Numeric(15, 2)), CAST(5 AS Numeric(2, 0)), CAST(N'2016-05-08 19:47:28.000' AS DateTime), CAST(2016 AS Numeric(4, 0)), CAST(5 AS Numeric(2, 0)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)))
INSERT [dbo].[payhst] ([staffid], [Names], [pic], [itemdescr], [pictype], [taxable], [scheme], [advance], [gradelvl], [deptcode], [bankid], [accountid], [pamount], [period], [paycaldate], [year], [month], [fixedtax], [totalallowance], [totaldeduction], [netpay]) VALUES (N'1023              ', N'JOJO KOKO TOTO                                                                  ', N'P1006     ', N'CAR LOAN                                          ', N'Dedu      ', 0, 0, 1, N'GL01      ', N'601       ', N'18000     ', N'346346346 ', CAST(0.00 AS Numeric(15, 2)), CAST(5 AS Numeric(2, 0)), CAST(N'2016-05-08 19:47:28.000' AS DateTime), CAST(2016 AS Numeric(4, 0)), CAST(5 AS Numeric(2, 0)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)))
INSERT [dbo].[payhst] ([staffid], [Names], [pic], [itemdescr], [pictype], [taxable], [scheme], [advance], [gradelvl], [deptcode], [bankid], [accountid], [pamount], [period], [paycaldate], [year], [month], [fixedtax], [totalallowance], [totaldeduction], [netpay]) VALUES (N'1023              ', N'JOJO KOKO TOTO                                                                  ', N'P10076    ', N'RENT LOAN                                         ', N'Dedu      ', 0, 0, 1, N'GL01      ', N'601       ', N'18000     ', N'346346346 ', CAST(0.00 AS Numeric(15, 2)), CAST(5 AS Numeric(2, 0)), CAST(N'2016-05-08 19:47:28.000' AS DateTime), CAST(2016 AS Numeric(4, 0)), CAST(5 AS Numeric(2, 0)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)))
INSERT [dbo].[payhst] ([staffid], [Names], [pic], [itemdescr], [pictype], [taxable], [scheme], [advance], [gradelvl], [deptcode], [bankid], [accountid], [pamount], [period], [paycaldate], [year], [month], [fixedtax], [totalallowance], [totaldeduction], [netpay]) VALUES (N'1023              ', N'JOJO KOKO TOTO                                                                  ', N'P1077     ', N'GRATUITY LOAN                                     ', N'Dedu      ', 0, 0, 1, N'GL01      ', N'601       ', N'18000     ', N'346346346 ', CAST(0.00 AS Numeric(15, 2)), CAST(5 AS Numeric(2, 0)), CAST(N'2016-05-08 19:47:28.000' AS DateTime), CAST(2016 AS Numeric(4, 0)), CAST(5 AS Numeric(2, 0)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)))
INSERT [dbo].[payhst] ([staffid], [Names], [pic], [itemdescr], [pictype], [taxable], [scheme], [advance], [gradelvl], [deptcode], [bankid], [accountid], [pamount], [period], [paycaldate], [year], [month], [fixedtax], [totalallowance], [totaldeduction], [netpay]) VALUES (N'1025              ', N'TOLANI THOMPSON DH                                                              ', N'P1001     ', N'BASIC SALARY                                      ', N'Basic     ', 1, 0, 0, N'GL01      ', N'601       ', N'18000     ', N'63464634  ', CAST(0.00 AS Numeric(15, 2)), CAST(5 AS Numeric(2, 0)), CAST(N'2016-05-08 19:47:28.000' AS DateTime), CAST(2016 AS Numeric(4, 0)), CAST(5 AS Numeric(2, 0)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)))
INSERT [dbo].[payhst] ([staffid], [Names], [pic], [itemdescr], [pictype], [taxable], [scheme], [advance], [gradelvl], [deptcode], [bankid], [accountid], [pamount], [period], [paycaldate], [year], [month], [fixedtax], [totalallowance], [totaldeduction], [netpay]) VALUES (N'1025              ', N'TOLANI THOMPSON DH                                                              ', N'P1002     ', N'TRANSPORT ALLOWANCE                               ', N'Allow     ', 1, 0, 0, N'GL01      ', N'601       ', N'18000     ', N'63464634  ', CAST(0.00 AS Numeric(15, 2)), CAST(5 AS Numeric(2, 0)), CAST(N'2016-05-08 19:47:28.000' AS DateTime), CAST(2016 AS Numeric(4, 0)), CAST(5 AS Numeric(2, 0)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)))
INSERT [dbo].[payhst] ([staffid], [Names], [pic], [itemdescr], [pictype], [taxable], [scheme], [advance], [gradelvl], [deptcode], [bankid], [accountid], [pamount], [period], [paycaldate], [year], [month], [fixedtax], [totalallowance], [totaldeduction], [netpay]) VALUES (N'1025              ', N'TOLANI THOMPSON DH                                                              ', N'P1003     ', N'HOUSING ALLOWANCE                                 ', N'Allow     ', 1, 0, 0, N'GL01      ', N'601       ', N'18000     ', N'63464634  ', CAST(0.00 AS Numeric(15, 2)), CAST(5 AS Numeric(2, 0)), CAST(N'2016-05-08 19:47:28.000' AS DateTime), CAST(2016 AS Numeric(4, 0)), CAST(5 AS Numeric(2, 0)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)))
INSERT [dbo].[payhst] ([staffid], [Names], [pic], [itemdescr], [pictype], [taxable], [scheme], [advance], [gradelvl], [deptcode], [bankid], [accountid], [pamount], [period], [paycaldate], [year], [month], [fixedtax], [totalallowance], [totaldeduction], [netpay]) VALUES (N'1025              ', N'TOLANI THOMPSON DH                                                              ', N'P1004     ', N'MEDICAL ALLOWANCE                                 ', N'Allow     ', 1, 0, 0, N'GL01      ', N'601       ', N'18000     ', N'63464634  ', CAST(0.00 AS Numeric(15, 2)), CAST(5 AS Numeric(2, 0)), CAST(N'2016-05-08 19:47:28.000' AS DateTime), CAST(2016 AS Numeric(4, 0)), CAST(5 AS Numeric(2, 0)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)))
INSERT [dbo].[payhst] ([staffid], [Names], [pic], [itemdescr], [pictype], [taxable], [scheme], [advance], [gradelvl], [deptcode], [bankid], [accountid], [pamount], [period], [paycaldate], [year], [month], [fixedtax], [totalallowance], [totaldeduction], [netpay]) VALUES (N'1025              ', N'TOLANI THOMPSON DH                                                              ', N'P1005     ', N'PENSION                                           ', N'Dedu      ', 0, 1, 0, N'GL01      ', N'601       ', N'18000     ', N'63464634  ', CAST(0.00 AS Numeric(15, 2)), CAST(5 AS Numeric(2, 0)), CAST(N'2016-05-08 19:47:28.000' AS DateTime), CAST(2016 AS Numeric(4, 0)), CAST(5 AS Numeric(2, 0)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)))
INSERT [dbo].[payhst] ([staffid], [Names], [pic], [itemdescr], [pictype], [taxable], [scheme], [advance], [gradelvl], [deptcode], [bankid], [accountid], [pamount], [period], [paycaldate], [year], [month], [fixedtax], [totalallowance], [totaldeduction], [netpay]) VALUES (N'1025              ', N'TOLANI THOMPSON DH                                                              ', N'P1006     ', N'CAR LOAN                                          ', N'Dedu      ', 0, 0, 1, N'GL01      ', N'601       ', N'18000     ', N'63464634  ', CAST(0.00 AS Numeric(15, 2)), CAST(5 AS Numeric(2, 0)), CAST(N'2016-05-08 19:47:28.000' AS DateTime), CAST(2016 AS Numeric(4, 0)), CAST(5 AS Numeric(2, 0)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)))
INSERT [dbo].[payhst] ([staffid], [Names], [pic], [itemdescr], [pictype], [taxable], [scheme], [advance], [gradelvl], [deptcode], [bankid], [accountid], [pamount], [period], [paycaldate], [year], [month], [fixedtax], [totalallowance], [totaldeduction], [netpay]) VALUES (N'1025              ', N'TOLANI THOMPSON DH                                                              ', N'P10076    ', N'RENT LOAN                                         ', N'Dedu      ', 0, 0, 1, N'GL01      ', N'601       ', N'18000     ', N'63464634  ', CAST(0.00 AS Numeric(15, 2)), CAST(5 AS Numeric(2, 0)), CAST(N'2016-05-08 19:47:28.000' AS DateTime), CAST(2016 AS Numeric(4, 0)), CAST(5 AS Numeric(2, 0)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)))
INSERT [dbo].[payhst] ([staffid], [Names], [pic], [itemdescr], [pictype], [taxable], [scheme], [advance], [gradelvl], [deptcode], [bankid], [accountid], [pamount], [period], [paycaldate], [year], [month], [fixedtax], [totalallowance], [totaldeduction], [netpay]) VALUES (N'1025              ', N'TOLANI THOMPSON DH                                                              ', N'P1077     ', N'GRATUITY LOAN                                     ', N'Dedu      ', 0, 0, 1, N'GL01      ', N'601       ', N'18000     ', N'63464634  ', CAST(0.00 AS Numeric(15, 2)), CAST(5 AS Numeric(2, 0)), CAST(N'2016-05-08 19:47:28.000' AS DateTime), CAST(2016 AS Numeric(4, 0)), CAST(5 AS Numeric(2, 0)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)))
INSERT [dbo].[payhst] ([staffid], [Names], [pic], [itemdescr], [pictype], [taxable], [scheme], [advance], [gradelvl], [deptcode], [bankid], [accountid], [pamount], [period], [paycaldate], [year], [month], [fixedtax], [totalallowance], [totaldeduction], [netpay]) VALUES (N'1026              ', N'LOLA OMTO WRITE                                                                 ', N'P1001     ', N'BASIC SALARY                                      ', N'Basic     ', 1, 0, 0, N'GL01      ', N'601       ', N'18000     ', N'          ', CAST(0.00 AS Numeric(15, 2)), CAST(5 AS Numeric(2, 0)), CAST(N'2016-05-08 19:47:28.000' AS DateTime), CAST(2016 AS Numeric(4, 0)), CAST(5 AS Numeric(2, 0)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)))
INSERT [dbo].[payhst] ([staffid], [Names], [pic], [itemdescr], [pictype], [taxable], [scheme], [advance], [gradelvl], [deptcode], [bankid], [accountid], [pamount], [period], [paycaldate], [year], [month], [fixedtax], [totalallowance], [totaldeduction], [netpay]) VALUES (N'1026              ', N'LOLA OMTO WRITE                                                                 ', N'P1002     ', N'TRANSPORT ALLOWANCE                               ', N'Allow     ', 1, 0, 0, N'GL01      ', N'601       ', N'18000     ', N'          ', CAST(0.00 AS Numeric(15, 2)), CAST(5 AS Numeric(2, 0)), CAST(N'2016-05-08 19:47:28.000' AS DateTime), CAST(2016 AS Numeric(4, 0)), CAST(5 AS Numeric(2, 0)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)))
INSERT [dbo].[payhst] ([staffid], [Names], [pic], [itemdescr], [pictype], [taxable], [scheme], [advance], [gradelvl], [deptcode], [bankid], [accountid], [pamount], [period], [paycaldate], [year], [month], [fixedtax], [totalallowance], [totaldeduction], [netpay]) VALUES (N'1026              ', N'LOLA OMTO WRITE                                                                 ', N'P1003     ', N'HOUSING ALLOWANCE                                 ', N'Allow     ', 1, 0, 0, N'GL01      ', N'601       ', N'18000     ', N'          ', CAST(0.00 AS Numeric(15, 2)), CAST(5 AS Numeric(2, 0)), CAST(N'2016-05-08 19:47:28.000' AS DateTime), CAST(2016 AS Numeric(4, 0)), CAST(5 AS Numeric(2, 0)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)))
INSERT [dbo].[payhst] ([staffid], [Names], [pic], [itemdescr], [pictype], [taxable], [scheme], [advance], [gradelvl], [deptcode], [bankid], [accountid], [pamount], [period], [paycaldate], [year], [month], [fixedtax], [totalallowance], [totaldeduction], [netpay]) VALUES (N'1026              ', N'LOLA OMTO WRITE                                                                 ', N'P1004     ', N'MEDICAL ALLOWANCE                                 ', N'Allow     ', 1, 0, 0, N'GL01      ', N'601       ', N'18000     ', N'          ', CAST(0.00 AS Numeric(15, 2)), CAST(5 AS Numeric(2, 0)), CAST(N'2016-05-08 19:47:28.000' AS DateTime), CAST(2016 AS Numeric(4, 0)), CAST(5 AS Numeric(2, 0)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)))
INSERT [dbo].[payhst] ([staffid], [Names], [pic], [itemdescr], [pictype], [taxable], [scheme], [advance], [gradelvl], [deptcode], [bankid], [accountid], [pamount], [period], [paycaldate], [year], [month], [fixedtax], [totalallowance], [totaldeduction], [netpay]) VALUES (N'1026              ', N'LOLA OMTO WRITE                                                                 ', N'P1005     ', N'PENSION                                           ', N'Dedu      ', 0, 1, 0, N'GL01      ', N'601       ', N'18000     ', N'          ', CAST(0.00 AS Numeric(15, 2)), CAST(5 AS Numeric(2, 0)), CAST(N'2016-05-08 19:47:28.000' AS DateTime), CAST(2016 AS Numeric(4, 0)), CAST(5 AS Numeric(2, 0)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)))
INSERT [dbo].[payhst] ([staffid], [Names], [pic], [itemdescr], [pictype], [taxable], [scheme], [advance], [gradelvl], [deptcode], [bankid], [accountid], [pamount], [period], [paycaldate], [year], [month], [fixedtax], [totalallowance], [totaldeduction], [netpay]) VALUES (N'1026              ', N'LOLA OMTO WRITE                                                                 ', N'P1006     ', N'CAR LOAN                                          ', N'Dedu      ', 0, 0, 1, N'GL01      ', N'601       ', N'18000     ', N'          ', CAST(0.00 AS Numeric(15, 2)), CAST(5 AS Numeric(2, 0)), CAST(N'2016-05-08 19:47:28.000' AS DateTime), CAST(2016 AS Numeric(4, 0)), CAST(5 AS Numeric(2, 0)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)))
INSERT [dbo].[payhst] ([staffid], [Names], [pic], [itemdescr], [pictype], [taxable], [scheme], [advance], [gradelvl], [deptcode], [bankid], [accountid], [pamount], [period], [paycaldate], [year], [month], [fixedtax], [totalallowance], [totaldeduction], [netpay]) VALUES (N'1026              ', N'LOLA OMTO WRITE                                                                 ', N'P10076    ', N'RENT LOAN                                         ', N'Dedu      ', 0, 0, 1, N'GL01      ', N'601       ', N'18000     ', N'          ', CAST(0.00 AS Numeric(15, 2)), CAST(5 AS Numeric(2, 0)), CAST(N'2016-05-08 19:47:28.000' AS DateTime), CAST(2016 AS Numeric(4, 0)), CAST(5 AS Numeric(2, 0)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)))
INSERT [dbo].[payhst] ([staffid], [Names], [pic], [itemdescr], [pictype], [taxable], [scheme], [advance], [gradelvl], [deptcode], [bankid], [accountid], [pamount], [period], [paycaldate], [year], [month], [fixedtax], [totalallowance], [totaldeduction], [netpay]) VALUES (N'1026              ', N'LOLA OMTO WRITE                                                                 ', N'P1077     ', N'GRATUITY LOAN                                     ', N'Dedu      ', 0, 0, 1, N'GL01      ', N'601       ', N'18000     ', N'          ', CAST(0.00 AS Numeric(15, 2)), CAST(5 AS Numeric(2, 0)), CAST(N'2016-05-08 19:47:28.000' AS DateTime), CAST(2016 AS Numeric(4, 0)), CAST(5 AS Numeric(2, 0)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)))
INSERT [dbo].[payhst] ([staffid], [Names], [pic], [itemdescr], [pictype], [taxable], [scheme], [advance], [gradelvl], [deptcode], [bankid], [accountid], [pamount], [period], [paycaldate], [year], [month], [fixedtax], [totalallowance], [totaldeduction], [netpay]) VALUES (N'1001              ', N'BADA SAMUEL SAMUEL                                                              ', N'P1001     ', N'BASIC SALARY                                      ', N'Basic     ', 1, 0, 0, N'GL01      ', N'603       ', N'18005     ', N'12124214  ', CAST(95000.00 AS Numeric(15, 2)), CAST(5 AS Numeric(2, 0)), CAST(N'2016-05-08 19:47:28.000' AS DateTime), CAST(2016 AS Numeric(4, 0)), CAST(5 AS Numeric(2, 0)), CAST(5500.00 AS Numeric(15, 2)), CAST(122000.00 AS Numeric(15, 2)), CAST(40500.00 AS Numeric(15, 2)), CAST(81500.00 AS Numeric(15, 2)))
INSERT [dbo].[payhst] ([staffid], [Names], [pic], [itemdescr], [pictype], [taxable], [scheme], [advance], [gradelvl], [deptcode], [bankid], [accountid], [pamount], [period], [paycaldate], [year], [month], [fixedtax], [totalallowance], [totaldeduction], [netpay]) VALUES (N'1001              ', N'BADA SAMUEL SAMUEL                                                              ', N'P1002     ', N'TRANSPORT ALLOWANCE                               ', N'Allow     ', 1, 0, 0, N'GL01      ', N'603       ', N'18005     ', N'12124214  ', CAST(15000.00 AS Numeric(15, 2)), CAST(5 AS Numeric(2, 0)), CAST(N'2016-05-08 19:47:28.000' AS DateTime), CAST(2016 AS Numeric(4, 0)), CAST(5 AS Numeric(2, 0)), CAST(5500.00 AS Numeric(15, 2)), CAST(122000.00 AS Numeric(15, 2)), CAST(40500.00 AS Numeric(15, 2)), CAST(81500.00 AS Numeric(15, 2)))
INSERT [dbo].[payhst] ([staffid], [Names], [pic], [itemdescr], [pictype], [taxable], [scheme], [advance], [gradelvl], [deptcode], [bankid], [accountid], [pamount], [period], [paycaldate], [year], [month], [fixedtax], [totalallowance], [totaldeduction], [netpay]) VALUES (N'1001              ', N'BADA SAMUEL SAMUEL                                                              ', N'P1003     ', N'HOUSING ALLOWANCE                                 ', N'Allow     ', 1, 0, 0, N'GL01      ', N'603       ', N'18005     ', N'12124214  ', CAST(12000.00 AS Numeric(15, 2)), CAST(5 AS Numeric(2, 0)), CAST(N'2016-05-08 19:47:28.000' AS DateTime), CAST(2016 AS Numeric(4, 0)), CAST(5 AS Numeric(2, 0)), CAST(5500.00 AS Numeric(15, 2)), CAST(122000.00 AS Numeric(15, 2)), CAST(40500.00 AS Numeric(15, 2)), CAST(81500.00 AS Numeric(15, 2)))
INSERT [dbo].[payhst] ([staffid], [Names], [pic], [itemdescr], [pictype], [taxable], [scheme], [advance], [gradelvl], [deptcode], [bankid], [accountid], [pamount], [period], [paycaldate], [year], [month], [fixedtax], [totalallowance], [totaldeduction], [netpay]) VALUES (N'1001              ', N'BADA SAMUEL SAMUEL                                                              ', N'P1004     ', N'MEDICAL ALLOWANCE                                 ', N'Allow     ', 1, 0, 0, N'GL01      ', N'603       ', N'18005     ', N'12124214  ', CAST(0.00 AS Numeric(15, 2)), CAST(5 AS Numeric(2, 0)), CAST(N'2016-05-08 19:47:28.000' AS DateTime), CAST(2016 AS Numeric(4, 0)), CAST(5 AS Numeric(2, 0)), CAST(5500.00 AS Numeric(15, 2)), CAST(122000.00 AS Numeric(15, 2)), CAST(40500.00 AS Numeric(15, 2)), CAST(81500.00 AS Numeric(15, 2)))
INSERT [dbo].[payhst] ([staffid], [Names], [pic], [itemdescr], [pictype], [taxable], [scheme], [advance], [gradelvl], [deptcode], [bankid], [accountid], [pamount], [period], [paycaldate], [year], [month], [fixedtax], [totalallowance], [totaldeduction], [netpay]) VALUES (N'1001              ', N'BADA SAMUEL SAMUEL                                                              ', N'P1005     ', N'PENSION                                           ', N'Dedu      ', 0, 1, 0, N'GL01      ', N'603       ', N'18005     ', N'12124214  ', CAST(5000.00 AS Numeric(15, 2)), CAST(5 AS Numeric(2, 0)), CAST(N'2016-05-08 19:47:28.000' AS DateTime), CAST(2016 AS Numeric(4, 0)), CAST(5 AS Numeric(2, 0)), CAST(5500.00 AS Numeric(15, 2)), CAST(122000.00 AS Numeric(15, 2)), CAST(40500.00 AS Numeric(15, 2)), CAST(81500.00 AS Numeric(15, 2)))
INSERT [dbo].[payhst] ([staffid], [Names], [pic], [itemdescr], [pictype], [taxable], [scheme], [advance], [gradelvl], [deptcode], [bankid], [accountid], [pamount], [period], [paycaldate], [year], [month], [fixedtax], [totalallowance], [totaldeduction], [netpay]) VALUES (N'1001              ', N'BADA SAMUEL SAMUEL                                                              ', N'P1006     ', N'CAR LOAN                                          ', N'Dedu      ', 0, 0, 1, N'GL01      ', N'603       ', N'18005     ', N'12124214  ', CAST(18000.00 AS Numeric(15, 2)), CAST(5 AS Numeric(2, 0)), CAST(N'2016-05-08 19:47:28.000' AS DateTime), CAST(2016 AS Numeric(4, 0)), CAST(5 AS Numeric(2, 0)), CAST(5500.00 AS Numeric(15, 2)), CAST(122000.00 AS Numeric(15, 2)), CAST(40500.00 AS Numeric(15, 2)), CAST(81500.00 AS Numeric(15, 2)))
INSERT [dbo].[payhst] ([staffid], [Names], [pic], [itemdescr], [pictype], [taxable], [scheme], [advance], [gradelvl], [deptcode], [bankid], [accountid], [pamount], [period], [paycaldate], [year], [month], [fixedtax], [totalallowance], [totaldeduction], [netpay]) VALUES (N'1001              ', N'BADA SAMUEL SAMUEL                                                              ', N'P10076    ', N'RENT LOAN                                         ', N'Dedu      ', 0, 0, 1, N'GL01      ', N'603       ', N'18005     ', N'12124214  ', CAST(12000.00 AS Numeric(15, 2)), CAST(5 AS Numeric(2, 0)), CAST(N'2016-05-08 19:47:28.000' AS DateTime), CAST(2016 AS Numeric(4, 0)), CAST(5 AS Numeric(2, 0)), CAST(5500.00 AS Numeric(15, 2)), CAST(122000.00 AS Numeric(15, 2)), CAST(40500.00 AS Numeric(15, 2)), CAST(81500.00 AS Numeric(15, 2)))
INSERT [dbo].[payhst] ([staffid], [Names], [pic], [itemdescr], [pictype], [taxable], [scheme], [advance], [gradelvl], [deptcode], [bankid], [accountid], [pamount], [period], [paycaldate], [year], [month], [fixedtax], [totalallowance], [totaldeduction], [netpay]) VALUES (N'1001              ', N'BADA SAMUEL SAMUEL                                                              ', N'P1077     ', N'GRATUITY LOAN                                     ', N'Dedu      ', 0, 0, 1, N'GL01      ', N'603       ', N'18005     ', N'12124214  ', CAST(0.00 AS Numeric(15, 2)), CAST(5 AS Numeric(2, 0)), CAST(N'2016-05-08 19:47:28.000' AS DateTime), CAST(2016 AS Numeric(4, 0)), CAST(5 AS Numeric(2, 0)), CAST(5500.00 AS Numeric(15, 2)), CAST(122000.00 AS Numeric(15, 2)), CAST(40500.00 AS Numeric(15, 2)), CAST(81500.00 AS Numeric(15, 2)))
INSERT [dbo].[payhst] ([staffid], [Names], [pic], [itemdescr], [pictype], [taxable], [scheme], [advance], [gradelvl], [deptcode], [bankid], [accountid], [pamount], [period], [paycaldate], [year], [month], [fixedtax], [totalallowance], [totaldeduction], [netpay]) VALUES (N'1003              ', N'BOLA TOPE TOPE                                                                  ', N'P1001     ', N'BASIC SALARY                                      ', N'Basic     ', 1, 0, 0, N'GL01      ', N'601       ', N'18002     ', N'242333    ', CAST(180000.00 AS Numeric(15, 2)), CAST(5 AS Numeric(2, 0)), CAST(N'2016-05-08 19:47:28.000' AS DateTime), CAST(2016 AS Numeric(4, 0)), CAST(5 AS Numeric(2, 0)), CAST(12000.00 AS Numeric(15, 2)), CAST(290000.00 AS Numeric(15, 2)), CAST(44000.00 AS Numeric(15, 2)), CAST(246000.00 AS Numeric(15, 2)))
INSERT [dbo].[payhst] ([staffid], [Names], [pic], [itemdescr], [pictype], [taxable], [scheme], [advance], [gradelvl], [deptcode], [bankid], [accountid], [pamount], [period], [paycaldate], [year], [month], [fixedtax], [totalallowance], [totaldeduction], [netpay]) VALUES (N'1003              ', N'BOLA TOPE TOPE                                                                  ', N'P1002     ', N'TRANSPORT ALLOWANCE                               ', N'Allow     ', 1, 0, 0, N'GL01      ', N'601       ', N'18002     ', N'242333    ', CAST(50000.00 AS Numeric(15, 2)), CAST(5 AS Numeric(2, 0)), CAST(N'2016-05-08 19:47:28.000' AS DateTime), CAST(2016 AS Numeric(4, 0)), CAST(5 AS Numeric(2, 0)), CAST(12000.00 AS Numeric(15, 2)), CAST(290000.00 AS Numeric(15, 2)), CAST(44000.00 AS Numeric(15, 2)), CAST(246000.00 AS Numeric(15, 2)))
INSERT [dbo].[payhst] ([staffid], [Names], [pic], [itemdescr], [pictype], [taxable], [scheme], [advance], [gradelvl], [deptcode], [bankid], [accountid], [pamount], [period], [paycaldate], [year], [month], [fixedtax], [totalallowance], [totaldeduction], [netpay]) VALUES (N'1003              ', N'BOLA TOPE TOPE                                                                  ', N'P1003     ', N'HOUSING ALLOWANCE                                 ', N'Allow     ', 1, 0, 0, N'GL01      ', N'601       ', N'18002     ', N'242333    ', CAST(0.00 AS Numeric(15, 2)), CAST(5 AS Numeric(2, 0)), CAST(N'2016-05-08 19:47:28.000' AS DateTime), CAST(2016 AS Numeric(4, 0)), CAST(5 AS Numeric(2, 0)), CAST(12000.00 AS Numeric(15, 2)), CAST(290000.00 AS Numeric(15, 2)), CAST(44000.00 AS Numeric(15, 2)), CAST(246000.00 AS Numeric(15, 2)))
INSERT [dbo].[payhst] ([staffid], [Names], [pic], [itemdescr], [pictype], [taxable], [scheme], [advance], [gradelvl], [deptcode], [bankid], [accountid], [pamount], [period], [paycaldate], [year], [month], [fixedtax], [totalallowance], [totaldeduction], [netpay]) VALUES (N'1003              ', N'BOLA TOPE TOPE                                                                  ', N'P1004     ', N'MEDICAL ALLOWANCE                                 ', N'Allow     ', 1, 0, 0, N'GL01      ', N'601       ', N'18002     ', N'242333    ', CAST(60000.00 AS Numeric(15, 2)), CAST(5 AS Numeric(2, 0)), CAST(N'2016-05-08 19:47:28.000' AS DateTime), CAST(2016 AS Numeric(4, 0)), CAST(5 AS Numeric(2, 0)), CAST(12000.00 AS Numeric(15, 2)), CAST(290000.00 AS Numeric(15, 2)), CAST(44000.00 AS Numeric(15, 2)), CAST(246000.00 AS Numeric(15, 2)))
INSERT [dbo].[payhst] ([staffid], [Names], [pic], [itemdescr], [pictype], [taxable], [scheme], [advance], [gradelvl], [deptcode], [bankid], [accountid], [pamount], [period], [paycaldate], [year], [month], [fixedtax], [totalallowance], [totaldeduction], [netpay]) VALUES (N'1003              ', N'BOLA TOPE TOPE                                                                  ', N'P1005     ', N'PENSION                                           ', N'Dedu      ', 0, 1, 0, N'GL01      ', N'601       ', N'18002     ', N'242333    ', CAST(15000.00 AS Numeric(15, 2)), CAST(5 AS Numeric(2, 0)), CAST(N'2016-05-08 19:47:28.000' AS DateTime), CAST(2016 AS Numeric(4, 0)), CAST(5 AS Numeric(2, 0)), CAST(12000.00 AS Numeric(15, 2)), CAST(290000.00 AS Numeric(15, 2)), CAST(44000.00 AS Numeric(15, 2)), CAST(246000.00 AS Numeric(15, 2)))
INSERT [dbo].[payhst] ([staffid], [Names], [pic], [itemdescr], [pictype], [taxable], [scheme], [advance], [gradelvl], [deptcode], [bankid], [accountid], [pamount], [period], [paycaldate], [year], [month], [fixedtax], [totalallowance], [totaldeduction], [netpay]) VALUES (N'1003              ', N'BOLA TOPE TOPE                                                                  ', N'P1006     ', N'CAR LOAN                                          ', N'Dedu      ', 0, 0, 1, N'GL01      ', N'601       ', N'18002     ', N'242333    ', CAST(5000.00 AS Numeric(15, 2)), CAST(5 AS Numeric(2, 0)), CAST(N'2016-05-08 19:47:28.000' AS DateTime), CAST(2016 AS Numeric(4, 0)), CAST(5 AS Numeric(2, 0)), CAST(12000.00 AS Numeric(15, 2)), CAST(290000.00 AS Numeric(15, 2)), CAST(44000.00 AS Numeric(15, 2)), CAST(246000.00 AS Numeric(15, 2)))
INSERT [dbo].[payhst] ([staffid], [Names], [pic], [itemdescr], [pictype], [taxable], [scheme], [advance], [gradelvl], [deptcode], [bankid], [accountid], [pamount], [period], [paycaldate], [year], [month], [fixedtax], [totalallowance], [totaldeduction], [netpay]) VALUES (N'1003              ', N'BOLA TOPE TOPE                                                                  ', N'P10076    ', N'RENT LOAN                                         ', N'Dedu      ', 0, 0, 1, N'GL01      ', N'601       ', N'18002     ', N'242333    ', CAST(12000.00 AS Numeric(15, 2)), CAST(5 AS Numeric(2, 0)), CAST(N'2016-05-08 19:47:28.000' AS DateTime), CAST(2016 AS Numeric(4, 0)), CAST(5 AS Numeric(2, 0)), CAST(12000.00 AS Numeric(15, 2)), CAST(290000.00 AS Numeric(15, 2)), CAST(44000.00 AS Numeric(15, 2)), CAST(246000.00 AS Numeric(15, 2)))
INSERT [dbo].[payhst] ([staffid], [Names], [pic], [itemdescr], [pictype], [taxable], [scheme], [advance], [gradelvl], [deptcode], [bankid], [accountid], [pamount], [period], [paycaldate], [year], [month], [fixedtax], [totalallowance], [totaldeduction], [netpay]) VALUES (N'1003              ', N'BOLA TOPE TOPE                                                                  ', N'P1077     ', N'GRATUITY LOAN                                     ', N'Dedu      ', 0, 0, 1, N'GL01      ', N'601       ', N'18002     ', N'242333    ', CAST(0.00 AS Numeric(15, 2)), CAST(5 AS Numeric(2, 0)), CAST(N'2016-05-08 19:47:28.000' AS DateTime), CAST(2016 AS Numeric(4, 0)), CAST(5 AS Numeric(2, 0)), CAST(12000.00 AS Numeric(15, 2)), CAST(290000.00 AS Numeric(15, 2)), CAST(44000.00 AS Numeric(15, 2)), CAST(246000.00 AS Numeric(15, 2)))
INSERT [dbo].[payhst] ([staffid], [Names], [pic], [itemdescr], [pictype], [taxable], [scheme], [advance], [gradelvl], [deptcode], [bankid], [accountid], [pamount], [period], [paycaldate], [year], [month], [fixedtax], [totalallowance], [totaldeduction], [netpay]) VALUES (N'1004              ', N'YUSUF LAMIDO LAMIO                                                              ', N'P1001     ', N'BASIC SALARY                                      ', N'Basic     ', 1, 0, 0, N'GL01      ', N'601       ', N'18000     ', N'233223434 ', CAST(0.00 AS Numeric(15, 2)), CAST(5 AS Numeric(2, 0)), CAST(N'2016-05-08 19:47:28.000' AS DateTime), CAST(2016 AS Numeric(4, 0)), CAST(5 AS Numeric(2, 0)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)))
INSERT [dbo].[payhst] ([staffid], [Names], [pic], [itemdescr], [pictype], [taxable], [scheme], [advance], [gradelvl], [deptcode], [bankid], [accountid], [pamount], [period], [paycaldate], [year], [month], [fixedtax], [totalallowance], [totaldeduction], [netpay]) VALUES (N'1004              ', N'YUSUF LAMIDO LAMIO                                                              ', N'P1002     ', N'TRANSPORT ALLOWANCE                               ', N'Allow     ', 1, 0, 0, N'GL01      ', N'601       ', N'18000     ', N'233223434 ', CAST(0.00 AS Numeric(15, 2)), CAST(5 AS Numeric(2, 0)), CAST(N'2016-05-08 19:47:28.000' AS DateTime), CAST(2016 AS Numeric(4, 0)), CAST(5 AS Numeric(2, 0)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)))
INSERT [dbo].[payhst] ([staffid], [Names], [pic], [itemdescr], [pictype], [taxable], [scheme], [advance], [gradelvl], [deptcode], [bankid], [accountid], [pamount], [period], [paycaldate], [year], [month], [fixedtax], [totalallowance], [totaldeduction], [netpay]) VALUES (N'1004              ', N'YUSUF LAMIDO LAMIO                                                              ', N'P1003     ', N'HOUSING ALLOWANCE                                 ', N'Allow     ', 1, 0, 0, N'GL01      ', N'601       ', N'18000     ', N'233223434 ', CAST(0.00 AS Numeric(15, 2)), CAST(5 AS Numeric(2, 0)), CAST(N'2016-05-08 19:47:28.000' AS DateTime), CAST(2016 AS Numeric(4, 0)), CAST(5 AS Numeric(2, 0)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)))
INSERT [dbo].[payhst] ([staffid], [Names], [pic], [itemdescr], [pictype], [taxable], [scheme], [advance], [gradelvl], [deptcode], [bankid], [accountid], [pamount], [period], [paycaldate], [year], [month], [fixedtax], [totalallowance], [totaldeduction], [netpay]) VALUES (N'1004              ', N'YUSUF LAMIDO LAMIO                                                              ', N'P1004     ', N'MEDICAL ALLOWANCE                                 ', N'Allow     ', 1, 0, 0, N'GL01      ', N'601       ', N'18000     ', N'233223434 ', CAST(0.00 AS Numeric(15, 2)), CAST(5 AS Numeric(2, 0)), CAST(N'2016-05-08 19:47:28.000' AS DateTime), CAST(2016 AS Numeric(4, 0)), CAST(5 AS Numeric(2, 0)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)))
INSERT [dbo].[payhst] ([staffid], [Names], [pic], [itemdescr], [pictype], [taxable], [scheme], [advance], [gradelvl], [deptcode], [bankid], [accountid], [pamount], [period], [paycaldate], [year], [month], [fixedtax], [totalallowance], [totaldeduction], [netpay]) VALUES (N'1004              ', N'YUSUF LAMIDO LAMIO                                                              ', N'P1005     ', N'PENSION                                           ', N'Dedu      ', 0, 1, 0, N'GL01      ', N'601       ', N'18000     ', N'233223434 ', CAST(0.00 AS Numeric(15, 2)), CAST(5 AS Numeric(2, 0)), CAST(N'2016-05-08 19:47:28.000' AS DateTime), CAST(2016 AS Numeric(4, 0)), CAST(5 AS Numeric(2, 0)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)))
INSERT [dbo].[payhst] ([staffid], [Names], [pic], [itemdescr], [pictype], [taxable], [scheme], [advance], [gradelvl], [deptcode], [bankid], [accountid], [pamount], [period], [paycaldate], [year], [month], [fixedtax], [totalallowance], [totaldeduction], [netpay]) VALUES (N'1004              ', N'YUSUF LAMIDO LAMIO                                                              ', N'P1006     ', N'CAR LOAN                                          ', N'Dedu      ', 0, 0, 1, N'GL01      ', N'601       ', N'18000     ', N'233223434 ', CAST(0.00 AS Numeric(15, 2)), CAST(5 AS Numeric(2, 0)), CAST(N'2016-05-08 19:47:28.000' AS DateTime), CAST(2016 AS Numeric(4, 0)), CAST(5 AS Numeric(2, 0)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)))
INSERT [dbo].[payhst] ([staffid], [Names], [pic], [itemdescr], [pictype], [taxable], [scheme], [advance], [gradelvl], [deptcode], [bankid], [accountid], [pamount], [period], [paycaldate], [year], [month], [fixedtax], [totalallowance], [totaldeduction], [netpay]) VALUES (N'1004              ', N'YUSUF LAMIDO LAMIO                                                              ', N'P10076    ', N'RENT LOAN                                         ', N'Dedu      ', 0, 0, 1, N'GL01      ', N'601       ', N'18000     ', N'233223434 ', CAST(0.00 AS Numeric(15, 2)), CAST(5 AS Numeric(2, 0)), CAST(N'2016-05-08 19:47:28.000' AS DateTime), CAST(2016 AS Numeric(4, 0)), CAST(5 AS Numeric(2, 0)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)))
INSERT [dbo].[payhst] ([staffid], [Names], [pic], [itemdescr], [pictype], [taxable], [scheme], [advance], [gradelvl], [deptcode], [bankid], [accountid], [pamount], [period], [paycaldate], [year], [month], [fixedtax], [totalallowance], [totaldeduction], [netpay]) VALUES (N'1004              ', N'YUSUF LAMIDO LAMIO                                                              ', N'P1077     ', N'GRATUITY LOAN                                     ', N'Dedu      ', 0, 0, 1, N'GL01      ', N'601       ', N'18000     ', N'233223434 ', CAST(0.00 AS Numeric(15, 2)), CAST(5 AS Numeric(2, 0)), CAST(N'2016-05-08 19:47:28.000' AS DateTime), CAST(2016 AS Numeric(4, 0)), CAST(5 AS Numeric(2, 0)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)))
INSERT [dbo].[payhst] ([staffid], [Names], [pic], [itemdescr], [pictype], [taxable], [scheme], [advance], [gradelvl], [deptcode], [bankid], [accountid], [pamount], [period], [paycaldate], [year], [month], [fixedtax], [totalallowance], [totaldeduction], [netpay]) VALUES (N'1005              ', N'JAMES THOMPSON SAMUEL                                                           ', N'P1001     ', N'BASIC SALARY                                      ', N'Basic     ', 1, 0, 0, N'GL01      ', N'601       ', N'18000     ', N'45454545  ', CAST(0.00 AS Numeric(15, 2)), CAST(5 AS Numeric(2, 0)), CAST(N'2016-05-08 19:47:28.000' AS DateTime), CAST(2016 AS Numeric(4, 0)), CAST(5 AS Numeric(2, 0)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)))
INSERT [dbo].[payhst] ([staffid], [Names], [pic], [itemdescr], [pictype], [taxable], [scheme], [advance], [gradelvl], [deptcode], [bankid], [accountid], [pamount], [period], [paycaldate], [year], [month], [fixedtax], [totalallowance], [totaldeduction], [netpay]) VALUES (N'1005              ', N'JAMES THOMPSON SAMUEL                                                           ', N'P1002     ', N'TRANSPORT ALLOWANCE                               ', N'Allow     ', 1, 0, 0, N'GL01      ', N'601       ', N'18000     ', N'45454545  ', CAST(0.00 AS Numeric(15, 2)), CAST(5 AS Numeric(2, 0)), CAST(N'2016-05-08 19:47:28.000' AS DateTime), CAST(2016 AS Numeric(4, 0)), CAST(5 AS Numeric(2, 0)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)))
INSERT [dbo].[payhst] ([staffid], [Names], [pic], [itemdescr], [pictype], [taxable], [scheme], [advance], [gradelvl], [deptcode], [bankid], [accountid], [pamount], [period], [paycaldate], [year], [month], [fixedtax], [totalallowance], [totaldeduction], [netpay]) VALUES (N'1005              ', N'JAMES THOMPSON SAMUEL                                                           ', N'P1003     ', N'HOUSING ALLOWANCE                                 ', N'Allow     ', 1, 0, 0, N'GL01      ', N'601       ', N'18000     ', N'45454545  ', CAST(0.00 AS Numeric(15, 2)), CAST(5 AS Numeric(2, 0)), CAST(N'2016-05-08 19:47:28.000' AS DateTime), CAST(2016 AS Numeric(4, 0)), CAST(5 AS Numeric(2, 0)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)), CAST(0.00 AS Numeric(15, 2)))
INSERT [dbo].[payitems] ([itemcode], [itemdescr], [itemtype], [advance], [scheme], [taxable], [glcode], [acmode], [pay]) VALUES (N'P1001     ', N'BASIC SALARY                                                                              ', N'Basic     ', 0, 0, 1, N'25101     ', N'cr        ', 1)
INSERT [dbo].[payitems] ([itemcode], [itemdescr], [itemtype], [advance], [scheme], [taxable], [glcode], [acmode], [pay]) VALUES (N'P1002     ', N'TRANSPORT ALLOWANCE                                                                       ', N'Allow     ', 0, 0, 1, N'25101     ', N'cr        ', 1)
INSERT [dbo].[payitems] ([itemcode], [itemdescr], [itemtype], [advance], [scheme], [taxable], [glcode], [acmode], [pay]) VALUES (N'P1003     ', N'HOUSING ALLOWANCE                                                                         ', N'Allow     ', 0, 0, 1, N'25101     ', N'cr        ', 1)
INSERT [dbo].[payitems] ([itemcode], [itemdescr], [itemtype], [advance], [scheme], [taxable], [glcode], [acmode], [pay]) VALUES (N'P1004     ', N'MEDICAL ALLOWANCE                                                                         ', N'Allow     ', 0, 0, 1, N'25101     ', N'cr        ', 1)
INSERT [dbo].[payitems] ([itemcode], [itemdescr], [itemtype], [advance], [scheme], [taxable], [glcode], [acmode], [pay]) VALUES (N'P1005     ', N'PENSION                                                                                   ', N'Dedu      ', 0, 1, 0, N'25101     ', N'dr        ', 1)
INSERT [dbo].[payitems] ([itemcode], [itemdescr], [itemtype], [advance], [scheme], [taxable], [glcode], [acmode], [pay]) VALUES (N'P1006     ', N'CAR LOAN                                                                                  ', N'Dedu      ', 1, 0, 0, N'25101     ', N'dr        ', 1)
INSERT [dbo].[payitems] ([itemcode], [itemdescr], [itemtype], [advance], [scheme], [taxable], [glcode], [acmode], [pay]) VALUES (N'P10076    ', N'RENT LOAN                                                                                 ', N'Dedu      ', 1, 0, 0, N'70000     ', N'cr        ', 1)
INSERT [dbo].[payitems] ([itemcode], [itemdescr], [itemtype], [advance], [scheme], [taxable], [glcode], [acmode], [pay]) VALUES (N'P1077     ', N'GRATUITY LOAN                                                                             ', N'Dedu      ', 1, 0, 0, N'25101     ', N'dr        ', 1)
INSERT [dbo].[payitems] ([itemcode], [itemdescr], [itemtype], [advance], [scheme], [taxable], [glcode], [acmode], [pay]) VALUES (N'P1078     ', N'UTILITIES                                                                                 ', N'Allow     ', 0, 0, 0, N'          ', N'          ', 1)
INSERT [dbo].[payitems] ([itemcode], [itemdescr], [itemtype], [advance], [scheme], [taxable], [glcode], [acmode], [pay]) VALUES (N'P1079     ', N'DRESSING                                                                                  ', N'Allow     ', 0, 0, 0, N'          ', N'          ', 1)
INSERT [dbo].[payitems] ([itemcode], [itemdescr], [itemtype], [advance], [scheme], [taxable], [glcode], [acmode], [pay]) VALUES (N'P1080     ', N'RSA PENSION(EMPLOYEE)                                                                     ', N'Dedu      ', 0, 0, 0, N'          ', N'          ', 1)
INSERT [dbo].[payitems] ([itemcode], [itemdescr], [itemtype], [advance], [scheme], [taxable], [glcode], [acmode], [pay]) VALUES (N'P1081     ', N'RSA PENSION(EMPLOYER)                                                                     ', N'Dedu      ', 0, 0, 0, N'          ', N'          ', 1)
INSERT [dbo].[payitems] ([itemcode], [itemdescr], [itemtype], [advance], [scheme], [taxable], [glcode], [acmode], [pay]) VALUES (N'P1083     ', N'SALARY ADVANCE                                                                            ', N'Dedu      ', 0, 0, 0, N'          ', N'          ', 1)
INSERT [dbo].[payitems] ([itemcode], [itemdescr], [itemtype], [advance], [scheme], [taxable], [glcode], [acmode], [pay]) VALUES (N'P1084     ', N'PENALTY                                                                                   ', N'Dedu      ', 0, 0, 0, N'          ', N'          ', 1)
INSERT [dbo].[payitems] ([itemcode], [itemdescr], [itemtype], [advance], [scheme], [taxable], [glcode], [acmode], [pay]) VALUES (N'P1085     ', N'LEAVE ALLOWANCE                                                                           ', N'Allow     ', 0, 0, 0, N'          ', N'          ', 1)
INSERT [dbo].[payitems] ([itemcode], [itemdescr], [itemtype], [advance], [scheme], [taxable], [glcode], [acmode], [pay]) VALUES (N'P1086     ', N'WEEK  ALLOWANCE (OVERTIME)                                                                ', N'Allow     ', 0, 0, 0, N'          ', N'          ', 1)
INSERT [dbo].[payitems] ([itemcode], [itemdescr], [itemtype], [advance], [scheme], [taxable], [glcode], [acmode], [pay]) VALUES (N'P1087     ', N'ARREAS/REIMBURSEMENT                                                                      ', N'Allow     ', 0, 0, 0, N'          ', N'          ', 1)
INSERT [dbo].[payitems] ([itemcode], [itemdescr], [itemtype], [advance], [scheme], [taxable], [glcode], [acmode], [pay]) VALUES (N'P1088     ', N'LOAN                                                                                      ', N'Dedu      ', 1, 0, 0, N'          ', N'          ', 1)
INSERT [dbo].[premiumplan] ([code1], [descr], [AMOUNT], [Type]) VALUES (N'HP001               ', N'INDIVIDUAL - CLASSIC                                                            ', CAST(24500.00 AS Numeric(18, 2)), N'Individual     ')
INSERT [dbo].[premiumplan] ([code1], [descr], [AMOUNT], [Type]) VALUES (N'HP002               ', N'INDIVIDUAL  - GOLD                                                              ', CAST(39000.00 AS Numeric(18, 2)), N'Individual     ')
INSERT [dbo].[premiumplan] ([code1], [descr], [AMOUNT], [Type]) VALUES (N'HP003               ', N'INDIVIDUAL  - DIAMOND                                                           ', CAST(64500.00 AS Numeric(18, 2)), N'Individual     ')
INSERT [dbo].[premiumplan] ([code1], [descr], [AMOUNT], [Type]) VALUES (N'HP004               ', N'INDIVIDUAL  - DIAMOND PLUS                                                      ', CAST(99500.00 AS Numeric(18, 2)), N'Individual     ')
INSERT [dbo].[premiumplan] ([code1], [descr], [AMOUNT], [Type]) VALUES (N'HP005               ', N'COMPARE                                                                         ', CAST(200000.00 AS Numeric(18, 2)), N'               ')
INSERT [dbo].[premiumplan] ([code1], [descr], [AMOUNT], [Type]) VALUES (N'HP006               ', N'INDIVIDUAL  - BRONZE                                                            ', CAST(15500.00 AS Numeric(18, 2)), N'Individual     ')
INSERT [dbo].[premiumplan] ([code1], [descr], [AMOUNT], [Type]) VALUES (N'HP007               ', N'FAMILY  - BRONZE                                                                ', CAST(69750.00 AS Numeric(18, 2)), N'Family         ')
INSERT [dbo].[premiumplan] ([code1], [descr], [AMOUNT], [Type]) VALUES (N'HP008               ', N'FAMILY  - CLASSIC                                                               ', CAST(110249.64 AS Numeric(18, 2)), N'Family         ')
INSERT [dbo].[premiumplan] ([code1], [descr], [AMOUNT], [Type]) VALUES (N'HP010               ', N'FAMILY  - GOLD                                                                  ', CAST(175500.00 AS Numeric(18, 2)), N'Family         ')
INSERT [dbo].[premiumplan] ([code1], [descr], [AMOUNT], [Type]) VALUES (N'HP011               ', N'FAMILY   - DIAMOND                                                              ', CAST(290250.00 AS Numeric(18, 2)), N'Family         ')
INSERT [dbo].[premiumplan] ([code1], [descr], [AMOUNT], [Type]) VALUES (N'HP012               ', N'FAMILY   - DIAMOND PLUS                                                         ', CAST(447750.00 AS Numeric(18, 2)), N'Family         ')
INSERT [dbo].[premiumplan] ([code1], [descr], [AMOUNT], [Type]) VALUES (N'NHIS                ', N'NHIS NIGERIA                                                                    ', CAST(1400.00 AS Numeric(18, 2)), NULL)
INSERT [dbo].[reports] ([reportid], [reportname], [type], [awitch], [orderby]) VALUES (N'101 ', N'Enrollee Listing By Oganisation                                       ', N'MD        ', 1, CAST(1 AS Numeric(18, 0)))
INSERT [dbo].[reports] ([reportid], [reportname], [type], [awitch], [orderby]) VALUES (N'102 ', N'Hospital Listing Report                                               ', N'MD        ', 1, CAST(6 AS Numeric(18, 0)))
INSERT [dbo].[reports] ([reportid], [reportname], [type], [awitch], [orderby]) VALUES (N'103 ', N'Code Setup Report                                                     ', N'MD        ', 1, NULL)
INSERT [dbo].[reports] ([reportid], [reportname], [type], [awitch], [orderby]) VALUES (N'106 ', N'Organization Listing Report                                           ', N'MD        ', 1, CAST(4 AS Numeric(18, 0)))
INSERT [dbo].[reports] ([reportid], [reportname], [type], [awitch], [orderby]) VALUES (N'107 ', N'HCP Payment Register/Vetting Report                                   ', N'MD        ', 1, CAST(7 AS Numeric(18, 0)))
INSERT [dbo].[reports] ([reportid], [reportname], [type], [awitch], [orderby]) VALUES (N'108 ', N'Payment Approvals / History                                           ', N'MD        ', 1, NULL)
INSERT [dbo].[reports] ([reportid], [reportname], [type], [awitch], [orderby]) VALUES (N'109 ', N'Treatment Authorization Report                                        ', N'MD        ', 1, NULL)
INSERT [dbo].[reports] ([reportid], [reportname], [type], [awitch], [orderby]) VALUES (N'110 ', N'Staff Listing                                                         ', N'PER       ', 1, NULL)
INSERT [dbo].[reports] ([reportid], [reportname], [type], [awitch], [orderby]) VALUES (N'111 ', N'Chart of Account                                                      ', N'FIN       ', 1, NULL)
INSERT [dbo].[reports] ([reportid], [reportname], [type], [awitch], [orderby]) VALUES (N'112 ', N'Fixed Asset Report                                                    ', N'FIN       ', 1, NULL)
INSERT [dbo].[reports] ([reportid], [reportname], [type], [awitch], [orderby]) VALUES (N'113 ', N'Customer Listing Report                                               ', N'FIN       ', 1, NULL)
INSERT [dbo].[reports] ([reportid], [reportname], [type], [awitch], [orderby]) VALUES (N'114 ', N'Vendor Listing Report                                                 ', N'FIN       ', 1, NULL)
INSERT [dbo].[reports] ([reportid], [reportname], [type], [awitch], [orderby]) VALUES (N'115 ', N'Sales /Debtor Invoice                                                 ', N'FIN       ', 1, NULL)
INSERT [dbo].[reports] ([reportid], [reportname], [type], [awitch], [orderby]) VALUES (N'116 ', N'Purchase/Creditors  Invoice                                           ', N'FIN       ', 1, NULL)
INSERT [dbo].[reports] ([reportid], [reportname], [type], [awitch], [orderby]) VALUES (N'117 ', N'Sales \<Receipts                                                      ', N'FIN       ', 1, NULL)
INSERT [dbo].[reports] ([reportid], [reportname], [type], [awitch], [orderby]) VALUES (N'119 ', N'Payrol Earning List                                                   ', N'FIN       ', 1, NULL)
INSERT [dbo].[reports] ([reportid], [reportname], [type], [awitch], [orderby]) VALUES (N'120 ', N'Payrol Deduction Listing                                              ', N'FIN       ', 1, NULL)
INSERT [dbo].[reports] ([reportid], [reportname], [type], [awitch], [orderby]) VALUES (N'122 ', N'Birthday Report                                                       ', N'PER       ', 1, NULL)
INSERT [dbo].[reports] ([reportid], [reportname], [type], [awitch], [orderby]) VALUES (N'123 ', N'Inactive Enrollee Listing Report                                      ', N'MD        ', 1, CAST(2 AS Numeric(18, 0)))
INSERT [dbo].[reports] ([reportid], [reportname], [type], [awitch], [orderby]) VALUES (N'124 ', N'Enrollee Listing By HCP                                               ', N'MD        ', 1, CAST(3 AS Numeric(18, 0)))
INSERT [dbo].[reports] ([reportid], [reportname], [type], [awitch], [orderby]) VALUES (N'125 ', N'Ailment Setup                                                         ', N'MD        ', 1, NULL)
INSERT [dbo].[reports] ([reportid], [reportname], [type], [awitch], [orderby]) VALUES (N'126 ', N'Health Plan Setup                                                     ', N'MD        ', 1, NULL)
INSERT [dbo].[reports] ([reportid], [reportname], [type], [awitch], [orderby]) VALUES (N'127 ', N'Active/Inactive Enrollee Listing Report                               ', N'MD        ', 1, CAST(5 AS Numeric(18, 0)))
INSERT [dbo].[reports] ([reportid], [reportname], [type], [awitch], [orderby]) VALUES (N'128 ', N'Payment By period                                                     ', N'FIN       ', 1, NULL)
INSERT [dbo].[reports] ([reportid], [reportname], [type], [awitch], [orderby]) VALUES (N'129 ', N'Disputed/differential  amount by facilities                           ', N'FIN       ', 1, NULL)
INSERT [dbo].[reports] ([reportid], [reportname], [type], [awitch], [orderby]) VALUES (N'130 ', N'Sales ledger                                                          ', N'FIN       ', 1, NULL)
INSERT [dbo].[reports] ([reportid], [reportname], [type], [awitch], [orderby]) VALUES (N'131 ', N'Hospital Listing Report by Date Registered                            ', N'MD        ', 1, NULL)
INSERT [dbo].[reports] ([reportid], [reportname], [type], [awitch], [orderby]) VALUES (N'132 ', N'Leave Report                                                          ', N'PER       ', 1, NULL)
INSERT [dbo].[reports] ([reportid], [reportname], [type], [awitch], [orderby]) VALUES (N'133 ', N'Job Appraisal Report                                                  ', N'PER       ', 1, NULL)
INSERT [dbo].[reports] ([reportid], [reportname], [type], [awitch], [orderby]) VALUES (N'134 ', N'Satff Payslip                                                         ', N'FIN       ', 1, NULL)
INSERT [dbo].[reward] ([code], [desc1], [begin1], [end1], [option1], [rwdcode]) VALUES (N'GRD-1', N'EXCELLENT           ', CAST(75 AS Numeric(3, 0)), CAST(100 AS Numeric(3, 0)), CAST(1 AS Numeric(1, 0)), N'001  ')
INSERT [dbo].[reward] ([code], [desc1], [begin1], [end1], [option1], [rwdcode]) VALUES (N'GRD-2', N'VERY GOOD           ', CAST(65 AS Numeric(3, 0)), CAST(74 AS Numeric(3, 0)), CAST(1 AS Numeric(1, 0)), N'001  ')
INSERT [dbo].[reward] ([code], [desc1], [begin1], [end1], [option1], [rwdcode]) VALUES (N'GRD-3', N'GOOD                ', CAST(60 AS Numeric(3, 0)), CAST(64 AS Numeric(3, 0)), CAST(1 AS Numeric(1, 0)), N'004  ')
INSERT [dbo].[reward] ([code], [desc1], [begin1], [end1], [option1], [rwdcode]) VALUES (N'GRD-4', N'FAIR-03             ', CAST(55 AS Numeric(3, 0)), CAST(59 AS Numeric(3, 0)), CAST(1 AS Numeric(1, 0)), N'SAL-I')
INSERT [dbo].[reward] ([code], [desc1], [begin1], [end1], [option1], [rwdcode]) VALUES (N'GRD-5', N'FAIR-1              ', CAST(50 AS Numeric(3, 0)), CAST(54 AS Numeric(3, 0)), CAST(1 AS Numeric(1, 0)), N'SAL-I')
INSERT [dbo].[reward] ([code], [desc1], [begin1], [end1], [option1], [rwdcode]) VALUES (N'GRD-6', N'FAIR-2              ', CAST(45 AS Numeric(3, 0)), CAST(49 AS Numeric(3, 0)), CAST(1 AS Numeric(1, 0)), N'RVW  ')
INSERT [dbo].[reward] ([code], [desc1], [begin1], [end1], [option1], [rwdcode]) VALUES (N'GRD-7', N'POOR-0              ', CAST(30 AS Numeric(3, 0)), CAST(44 AS Numeric(3, 0)), CAST(1 AS Numeric(1, 0)), N'WRN  ')
INSERT [dbo].[reward] ([code], [desc1], [begin1], [end1], [option1], [rwdcode]) VALUES (N'GRD-8', N'POOR-1              ', CAST(15 AS Numeric(3, 0)), CAST(29 AS Numeric(3, 0)), CAST(1 AS Numeric(1, 0)), N'WRN  ')
INSERT [dbo].[reward] ([code], [desc1], [begin1], [end1], [option1], [rwdcode]) VALUES (N'GRD-9', N'POOR-2              ', CAST(0 AS Numeric(3, 0)), CAST(14 AS Numeric(3, 0)), CAST(1 AS Numeric(1, 0)), N'DTD  ')
INSERT [dbo].[setuptab] ([Dcapscrooltect], [Payrate]) VALUES (N'                  Welcome to DSNL Data Capture Manager, Select your assigned Folder to continue keying data, Centre No: is 7 didgit and Candidate No: is 10. Also An asterisk mark (*) will be used for any unreadable values and a null value.           ', CAST(30.00 AS Numeric(18, 2)))
INSERT [dbo].[stafftab] ([staffid], [surname], [firstname], [othernames], [title], [sex], [mstatus], [dengage], [dofb], [age], [tel], [email], [pofb], [natid], [address], [pfa], [lga], [state], [country], [cat], [position], [glevel], [bankid], [branch], [dept], [accountid], [accttype], [scode], [suspended], [leavedays], [leavebal], [officebranch], [lpromotedd], [suspendeddate], [ppicture], [spicture], [childpix1], [childpix2], [childpix3], [childpix4]) VALUES (N'ADMIN                    ', N'Dsnl                                              ', N'Administrator                                                                                       ', N'                                                                                ', NULL, NULL, N'Single         ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'237            ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[stafftab] ([staffid], [surname], [firstname], [othernames], [title], [sex], [mstatus], [dengage], [dofb], [age], [tel], [email], [pofb], [natid], [address], [pfa], [lga], [state], [country], [cat], [position], [glevel], [bankid], [branch], [dept], [accountid], [accttype], [scode], [suspended], [leavedays], [leavebal], [officebranch], [lpromotedd], [suspendeddate], [ppicture], [spicture], [childpix1], [childpix2], [childpix3], [childpix4]) VALUES (N'UH0013                   ', N'BADO                                              ', N'                                                                                                    ', N'                                                                                ', N'               ', N'        ', N'               ', CAST(N'2016-05-13 00:00:00.000' AS DateTime), CAST(N'2016-05-13 00:00:00.000' AS DateTime), N'     ', N'                                                                                               ', N'                                                                                               ', N'                                                                                     ', N'                                             ', N'                                                                                                                                                                                                             ', N'52             ', N'54             ', N'S10       ', N'USA            ', N'SR             ', N'ITMGT          ', N'GL01           ', N'18000          ', N'               ', N'RLT            ', N'                                   ', N'                              ', N'                              ', 0, CAST(0.00 AS Numeric(18, 2)), CAST(0.00 AS Numeric(18, 2)), N'BRAN10    ', CAST(N'2016-05-13 00:00:00.000' AS DateTime), CAST(N'2016-05-13 00:00:00.000' AS DateTime), N'\\10.6.11.2\dsnlHMOsystems\dsnlHMOsystems\dsnlHMOsystems\Images\spics.jpg                                               ', N'\\10.6.11.2\dsnlHMOsystems\dsnlHMOsystems\dsnlHMOsystems\Images\spics.jpg                                               ', N'\\10.6.11.2\dsnlHMOsystems\dsnlHMOsystems\dsnlHMOsystems\Images\spics.jpg                                               ', N'\\10.6.11.2\dsnlHMOsystems\dsnlHMOsystems\dsnlHMOsystems\Images\spics.jpg                                               ', N'\\10.6.11.2\dsnlHMOsystems\dsnlHMOsystems\dsnlHMOsystems\Images\spics.jpg                                               ', N'\\10.6.11.2\dsnlHMOsystems\dsnlHMOsystems\dsnlHMOsystems\Images\spics.jpg                                               ')
INSERT [dbo].[stafftab] ([staffid], [surname], [firstname], [othernames], [title], [sex], [mstatus], [dengage], [dofb], [age], [tel], [email], [pofb], [natid], [address], [pfa], [lga], [state], [country], [cat], [position], [glevel], [bankid], [branch], [dept], [accountid], [accttype], [scode], [suspended], [leavedays], [leavebal], [officebranch], [lpromotedd], [suspendeddate], [ppicture], [spicture], [childpix1], [childpix2], [childpix3], [childpix4]) VALUES (N'UH004                    ', N'IGBOKWE                                           ', N'CHIKAODI                                                                                            ', N'CHARLES                                                                         ', N'               ', N'        ', N'               ', CAST(N'2016-05-13 00:00:00.000' AS DateTime), CAST(N'2016-05-13 00:00:00.000' AS DateTime), N'     ', N'                                                                                               ', N'                                                                                               ', N'                                                                                     ', N'                                             ', N'                                                                                                                                                                                                             ', N'52             ', N'54             ', N'S10       ', N'USA            ', N'SR             ', N'ITMGT          ', N'GL01           ', N'18000          ', N'               ', N'RLT            ', N'                                   ', N'                              ', N'                              ', 0, CAST(0.00 AS Numeric(18, 2)), CAST(0.00 AS Numeric(18, 2)), N'BRAN10    ', CAST(N'2016-05-13 00:00:00.000' AS DateTime), CAST(N'2016-05-13 00:00:00.000' AS DateTime), N'\\10.6.11.2\dsnlHMOsystems\dsnlHMOsystems\dsnlHMOsystems\Images\spics.jpg                                               ', N'\\10.6.11.2\dsnlHMOsystems\dsnlHMOsystems\dsnlHMOsystems\Images\spics.jpg                                               ', N'\\10.6.11.2\dsnlHMOsystems\dsnlHMOsystems\dsnlHMOsystems\Images\spics.jpg                                               ', N'\\10.6.11.2\dsnlHMOsystems\dsnlHMOsystems\dsnlHMOsystems\Images\spics.jpg                                               ', N'\\10.6.11.2\dsnlHMOsystems\dsnlHMOsystems\dsnlHMOsystems\Images\spics.jpg                                               ', N'\\10.6.11.2\dsnlHMOsystems\dsnlHMOsystems\dsnlHMOsystems\Images\spics.jpg                                               ')
INSERT [dbo].[stafftab] ([staffid], [surname], [firstname], [othernames], [title], [sex], [mstatus], [dengage], [dofb], [age], [tel], [email], [pofb], [natid], [address], [pfa], [lga], [state], [country], [cat], [position], [glevel], [bankid], [branch], [dept], [accountid], [accttype], [scode], [suspended], [leavedays], [leavebal], [officebranch], [lpromotedd], [suspendeddate], [ppicture], [spicture], [childpix1], [childpix2], [childpix3], [childpix4]) VALUES (N'UH005                    ', N'ANI                                               ', N'ONYEKACHI                                                                                           ', N'FLORA                                                                           ', N'               ', N'        ', N'               ', CAST(N'2016-05-13 00:00:00.000' AS DateTime), CAST(N'2016-05-13 00:00:00.000' AS DateTime), N'     ', N'                                                                                               ', N'                                                                                               ', N'                                                                                     ', N'                                             ', N'                                                                                                                                                                                                             ', N'52             ', N'54             ', N'S10       ', N'USA            ', N'SR             ', N'ITMGT          ', N'GL01           ', N'18000          ', N'               ', N'RLT            ', N'                                   ', N'                              ', N'                              ', 0, CAST(0.00 AS Numeric(18, 2)), CAST(0.00 AS Numeric(18, 2)), N'BRAN10    ', CAST(N'2016-05-13 00:00:00.000' AS DateTime), CAST(N'2016-05-13 00:00:00.000' AS DateTime), N'\\10.6.11.2\dsnlHMOsystems\dsnlHMOsystems\dsnlHMOsystems\Images\spics.jpg                                               ', N'\\10.6.11.2\dsnlHMOsystems\dsnlHMOsystems\dsnlHMOsystems\Images\spics.jpg                                               ', N'\\10.6.11.2\dsnlHMOsystems\dsnlHMOsystems\dsnlHMOsystems\Images\spics.jpg                                               ', N'\\10.6.11.2\dsnlHMOsystems\dsnlHMOsystems\dsnlHMOsystems\Images\spics.jpg                                               ', N'\\10.6.11.2\dsnlHMOsystems\dsnlHMOsystems\dsnlHMOsystems\Images\spics.jpg                                               ', N'\\10.6.11.2\dsnlHMOsystems\dsnlHMOsystems\dsnlHMOsystems\Images\spics.jpg                                               ')
INSERT [dbo].[stafftab] ([staffid], [surname], [firstname], [othernames], [title], [sex], [mstatus], [dengage], [dofb], [age], [tel], [email], [pofb], [natid], [address], [pfa], [lga], [state], [country], [cat], [position], [glevel], [bankid], [branch], [dept], [accountid], [accttype], [scode], [suspended], [leavedays], [leavebal], [officebranch], [lpromotedd], [suspendeddate], [ppicture], [spicture], [childpix1], [childpix2], [childpix3], [childpix4]) VALUES (N'UH006                    ', N'ELENGA                                            ', N'GIFT                                                                                                ', N'                                                                                ', N'               ', N'        ', N'               ', CAST(N'2016-05-13 00:00:00.000' AS DateTime), CAST(N'2016-05-13 00:00:00.000' AS DateTime), N'     ', N'                                                                                               ', N'                                                                                               ', N'                                                                                     ', N'                                             ', N'                                                                                                                                                                                                             ', N'52             ', N'54             ', N'S10       ', N'USA            ', N'SR             ', N'ITMGT          ', N'GL01           ', N'18000          ', N'               ', N'RLT            ', N'                                   ', N'                              ', N'                              ', 0, CAST(0.00 AS Numeric(18, 2)), CAST(0.00 AS Numeric(18, 2)), N'BRAN10    ', CAST(N'2016-05-13 00:00:00.000' AS DateTime), CAST(N'2016-05-13 00:00:00.000' AS DateTime), N'\\10.6.11.2\dsnlHMOsystems\dsnlHMOsystems\dsnlHMOsystems\Images\spics.jpg                                               ', N'\\10.6.11.2\dsnlHMOsystems\dsnlHMOsystems\dsnlHMOsystems\Images\spics.jpg                                               ', N'\\10.6.11.2\dsnlHMOsystems\dsnlHMOsystems\dsnlHMOsystems\Images\spics.jpg                                               ', N'\\10.6.11.2\dsnlHMOsystems\dsnlHMOsystems\dsnlHMOsystems\Images\spics.jpg                                               ', N'\\10.6.11.2\dsnlHMOsystems\dsnlHMOsystems\dsnlHMOsystems\Images\spics.jpg                                               ', N'\\10.6.11.2\dsnlHMOsystems\dsnlHMOsystems\dsnlHMOsystems\Images\spics.jpg                                               ')
INSERT [dbo].[useracct] ([userid], [password], [names], [admin], [status], [appraise], [approve], [staffonline], [staffpin], [claimsinput], [claimsvetting]) VALUES (N'ADMIN          ', N'e182ebbc166d73366e7986813a7fc5f1                  ', N'Dsnl Administrator                                                                                                                                    ', 1, 1, 1, 1, 0, N'd41d8cd98f00b204e9800998ecf8427e                  ', 1, 1)
INSERT [dbo].[useracct] ([userid], [password], [names], [admin], [status], [appraise], [approve], [staffonline], [staffpin], [claimsinput], [claimsvetting]) VALUES (N'UH005          ', N'2aaffe8b2d98e63df61f96d8ac8ca2cb                  ', N'Ani Onyekachi                                                                                                                                         ', 0, 1, 1, 0, 0, N'                                                  ', 0, 0)
INSERT [dbo].[useracct] ([userid], [password], [names], [admin], [status], [appraise], [approve], [staffonline], [staffpin], [claimsinput], [claimsvetting]) VALUES (N'UH004          ', N'44ffe44097bbce02fbaa42734e92ae04                  ', N'IGBOKWE  CHIKAODI                                                                                                                                     ', 1, 1, 1, 1, 0, N'd41d8cd98f00b204e9800998ecf8427e                  ', 1, 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1001              ', N'M1        ', N'Company Setup                                                                                                           ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1001              ', N'M2        ', N'General Setup                                                                                                           ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1001              ', N'M3        ', N'Online Backup/Restore                                                                                                   ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1001              ', N'M4        ', N'Enrollment information                                                                                                  ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1001              ', N'M5        ', N'Organization information                                                                                                ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1001              ', N'M6        ', N'Hospital Information                                                                                                    ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1001              ', N'M7        ', N'HCP Payment Register/Vetting                                                                                            ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1001              ', N'M8        ', N'Payment Approvals / History                                                                                             ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1001              ', N'M10       ', N'Staff Information                                                                                                       ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1001              ', N'M9        ', N'Treatment Authorization                                                                                                 ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1001              ', N'M11       ', N'Job Appraisal                                                                                                           ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1001              ', N'M12       ', N'Leave Management                                                                                                        ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1001              ', N'M13       ', N'Staff Birthday                                                                                                          ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1001              ', N'M14       ', N'Account Main Menu                                                                                                       ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1001              ', N'M15       ', N'Chart of Accounts                                                                                                       ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1001              ', N'M16       ', N'Accounting Period Setup                                                                                                 ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1001              ', N'M17       ', N'Opening Balance                                                                                                         ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1001              ', N'M18       ', N'Bank Setup                                                                                                              ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1001              ', N'M19       ', N'Account Group Setup                                                                                                     ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1001              ', N'M20       ', N'Payroll Process                                                                                                         ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1001              ', N'M21       ', N'Fixed Asset                                                                                                             ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1001              ', N'M22       ', N'Receivable/Debtors Module                                                                                               ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1001              ', N'M23       ', N'Payable/Creditors Module                                                                                                ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1001              ', N'M25       ', N'General Ledger Module                                                                                                   ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1001              ', N'M26       ', N'Detail Report Dailog                                                                                                    ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1001              ', N'M27       ', N'List Reports                                                                                                            ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1001              ', N'M28       ', N'General Settings                                                                                                        ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1001              ', N'M29       ', N'User Account Management                                                                                                 ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1001              ', N'M30       ', N'Audit Trail Settings                                                                                                    ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1001              ', N'M31       ', N'Download/Upload Utility                                                                                                 ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1001              ', N'M33       ', N'Utilization fees                                                                                                        ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1002              ', N'M1        ', N'Company Setup                                                                                                           ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1002              ', N'M2        ', N'General Setup                                                                                                           ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1002              ', N'M3        ', N'Online Backup/Restore                                                                                                   ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1002              ', N'M4        ', N'Enrollment information                                                                                                  ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1002              ', N'M5        ', N'Organization information                                                                                                ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1002              ', N'M6        ', N'Hospital Information                                                                                                    ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1002              ', N'M7        ', N'HCP Payment Register/Vetting                                                                                            ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1002              ', N'M8        ', N'Payment Approvals / History                                                                                             ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1002              ', N'M10       ', N'Staff Information                                                                                                       ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1002              ', N'M9        ', N'Treatment Authorization                                                                                                 ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1002              ', N'M11       ', N'Job Appraisal                                                                                                           ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1002              ', N'M12       ', N'Leave Management                                                                                                        ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1002              ', N'M13       ', N'Staff Birthday                                                                                                          ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1002              ', N'M14       ', N'Account Main Menu                                                                                                       ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1002              ', N'M15       ', N'Chart of Accounts                                                                                                       ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1002              ', N'M16       ', N'Accounting Period Setup                                                                                                 ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1002              ', N'M17       ', N'Opening Balance                                                                                                         ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1002              ', N'M18       ', N'Bank Setup                                                                                                              ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1002              ', N'M19       ', N'Account Group Setup                                                                                                     ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1002              ', N'M20       ', N'Payroll Process                                                                                                         ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1002              ', N'M21       ', N'Fixed Asset                                                                                                             ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1002              ', N'M22       ', N'Receivable/Debtors Module                                                                                               ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1002              ', N'M23       ', N'Payable/Creditors Module                                                                                                ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1002              ', N'M25       ', N'General Ledger Module                                                                                                   ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1002              ', N'M26       ', N'Detail Report Dailog                                                                                                    ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1001              ', N'M32       ', N'Generate Enrollee ID Card                                                                                               ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1002              ', N'M27       ', N'List Reports                                                                                                            ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1002              ', N'M28       ', N'General Settings                                                                                                        ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1002              ', N'M29       ', N'User Account Management                                                                                                 ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1002              ', N'M30       ', N'Audit Trail Settings                                                                                                    ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1002              ', N'M31       ', N'Download/Upload Utility                                                                                                 ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1002              ', N'M32       ', N'Generate Enrollee ID Card                                                                                               ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1002              ', N'M33       ', N'Utilization fees                                                                                                        ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1003              ', N'M1        ', N'Company Setup                                                                                                           ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1003              ', N'M2        ', N'General Setup                                                                                                           ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1003              ', N'M3        ', N'Online Backup/Restore                                                                                                   ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1003              ', N'M4        ', N'Enrollment information                                                                                                  ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1003              ', N'M5        ', N'Organization information                                                                                                ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1003              ', N'M6        ', N'Hospital Information                                                                                                    ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1003              ', N'M7        ', N'HCP Payment Register/Vetting                                                                                            ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1003              ', N'M8        ', N'Payment Approvals / History                                                                                             ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1003              ', N'M10       ', N'Staff Information                                                                                                       ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1003              ', N'M9        ', N'Treatment Authorization                                                                                                 ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1003              ', N'M11       ', N'Job Appraisal                                                                                                           ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1003              ', N'M12       ', N'Leave Management                                                                                                        ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1003              ', N'M13       ', N'Staff Birthday                                                                                                          ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1003              ', N'M14       ', N'Account Main Menu                                                                                                       ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1003              ', N'M15       ', N'Chart of Accounts                                                                                                       ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1003              ', N'M16       ', N'Accounting Period Setup                                                                                                 ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1003              ', N'M17       ', N'Opening Balance                                                                                                         ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1003              ', N'M18       ', N'Bank Setup                                                                                                              ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1003              ', N'M19       ', N'Account Group Setup                                                                                                     ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1003              ', N'M20       ', N'Payroll Process                                                                                                         ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1003              ', N'M21       ', N'Fixed Asset                                                                                                             ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1003              ', N'M22       ', N'Receivable/Debtors Module                                                                                               ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1003              ', N'M23       ', N'Payable/Creditors Module                                                                                                ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1003              ', N'M25       ', N'General Ledger Module                                                                                                   ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1003              ', N'M26       ', N'Detail Report Dailog                                                                                                    ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1003              ', N'M27       ', N'List Reports                                                                                                            ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1003              ', N'M28       ', N'General Settings                                                                                                        ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1003              ', N'M29       ', N'User Account Management                                                                                                 ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1003              ', N'M30       ', N'Audit Trail Settings                                                                                                    ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1003              ', N'M31       ', N'Download/Upload Utility                                                                                                 ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1003              ', N'M32       ', N'Generate Enrollee ID Card                                                                                               ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1003              ', N'M33       ', N'Utilization fees                                                                                                        ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1004              ', N'M1        ', N'Company Setup                                                                                                           ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1004              ', N'M2        ', N'General Setup                                                                                                           ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1004              ', N'M3        ', N'Online Backup/Restore                                                                                                   ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1004              ', N'M4        ', N'Enrollment information                                                                                                  ', 0)
GO
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1004              ', N'M5        ', N'Organization information                                                                                                ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1004              ', N'M6        ', N'Hospital Information                                                                                                    ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1004              ', N'M7        ', N'HCP Payment Register/Vetting                                                                                            ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1004              ', N'M8        ', N'Payment Approvals / History                                                                                             ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1004              ', N'M10       ', N'Staff Information                                                                                                       ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1004              ', N'M9        ', N'Treatment Authorization                                                                                                 ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1004              ', N'M11       ', N'Job Appraisal                                                                                                           ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1004              ', N'M12       ', N'Leave Management                                                                                                        ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1004              ', N'M13       ', N'Staff Birthday                                                                                                          ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1004              ', N'M14       ', N'Account Main Menu                                                                                                       ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1004              ', N'M15       ', N'Chart of Accounts                                                                                                       ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1004              ', N'M16       ', N'Accounting Period Setup                                                                                                 ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1004              ', N'M17       ', N'Opening Balance                                                                                                         ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1004              ', N'M18       ', N'Bank Setup                                                                                                              ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1004              ', N'M19       ', N'Account Group Setup                                                                                                     ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1004              ', N'M20       ', N'Payroll Process                                                                                                         ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1004              ', N'M21       ', N'Fixed Asset                                                                                                             ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1004              ', N'M22       ', N'Receivable/Debtors Module                                                                                               ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1004              ', N'M23       ', N'Payable/Creditors Module                                                                                                ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1004              ', N'M25       ', N'General Ledger Module                                                                                                   ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1004              ', N'M26       ', N'Detail Report Dailog                                                                                                    ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1004              ', N'M27       ', N'List Reports                                                                                                            ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1004              ', N'M28       ', N'General Settings                                                                                                        ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1004              ', N'M29       ', N'User Account Management                                                                                                 ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1004              ', N'M30       ', N'Audit Trail Settings                                                                                                    ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1004              ', N'M31       ', N'Download/Upload Utility                                                                                                 ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1004              ', N'M32       ', N'Generate Enrollee ID Card                                                                                               ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'1004              ', N'M33       ', N'Utilization fees                                                                                                        ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'ADMIN             ', N'M1        ', N'Company Setup                                                                                                           ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'ADMIN             ', N'M2        ', N'General Setup                                                                                                           ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'ADMIN             ', N'M3        ', N'Online Backup/Restore                                                                                                   ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'ADMIN             ', N'M4        ', N'Enrollment information                                                                                                  ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'ADMIN             ', N'M5        ', N'Organization information                                                                                                ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'ADMIN             ', N'M6        ', N'Hospital Information                                                                                                    ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'ADMIN             ', N'M7        ', N'HCP Payment Register/Vetting                                                                                            ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'ADMIN             ', N'M8        ', N'Payment Approvals / History                                                                                             ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'ADMIN             ', N'M10       ', N'Staff Information                                                                                                       ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'ADMIN             ', N'M9        ', N'Treatment Authorization                                                                                                 ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'ADMIN             ', N'M11       ', N'Job Appraisal                                                                                                           ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'ADMIN             ', N'M12       ', N'Leave Management                                                                                                        ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'ADMIN             ', N'M13       ', N'Staff Birthday                                                                                                          ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'ADMIN             ', N'M14       ', N'Account Main Menu                                                                                                       ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'ADMIN             ', N'M15       ', N'Chart of Accounts                                                                                                       ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'ADMIN             ', N'M16       ', N'Accounting Period Setup                                                                                                 ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'ADMIN             ', N'M17       ', N'Opening Balance                                                                                                         ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'ADMIN             ', N'M18       ', N'Bank Setup                                                                                                              ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'ADMIN             ', N'M19       ', N'Account Group Setup                                                                                                     ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'ADMIN             ', N'M20       ', N'Payroll Process                                                                                                         ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'ADMIN             ', N'M21       ', N'Fixed Asset                                                                                                             ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'ADMIN             ', N'M22       ', N'Receivable/Debtors Module                                                                                               ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'ADMIN             ', N'M23       ', N'Payable/Creditors Module                                                                                                ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'ADMIN             ', N'M25       ', N'General Ledger Module                                                                                                   ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'ADMIN             ', N'M26       ', N'Detail Report Dailog                                                                                                    ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'ADMIN             ', N'M27       ', N'List Reports                                                                                                            ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'ADMIN             ', N'M28       ', N'General Settings                                                                                                        ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'ADMIN             ', N'M29       ', N'User Account Management                                                                                                 ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'ADMIN             ', N'M30       ', N'Audit Trail Settings                                                                                                    ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'ADMIN             ', N'M31       ', N'Download/Upload Utility                                                                                                 ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'ADMIN             ', N'M32       ', N'Generate Enrollee ID Card                                                                                               ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'ADMIN             ', N'M33       ', N'Utilization fees                                                                                                        ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'UH004             ', N'M19       ', N'Account Group Setup                                                                                                     ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'UH004             ', N'M14       ', N'Account Main Menu                                                                                                       ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'UH004             ', N'M16       ', N'Accounting Period Setup                                                                                                 ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'UH004             ', N'M30       ', N'Audit Trail Settings                                                                                                    ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'UH004             ', N'M18       ', N'Bank Setup                                                                                                              ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'UH004             ', N'M15       ', N'Chart of Accounts                                                                                                       ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'UH004             ', N'M1        ', N'Company Setup                                                                                                           ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'UH004             ', N'M26       ', N'Detail Report Dailog                                                                                                    ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'UH004             ', N'M31       ', N'Download/Upload Utility                                                                                                 ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'UH004             ', N'M4        ', N'Enrollment information                                                                                                  ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'UH004             ', N'M21       ', N'Fixed Asset                                                                                                             ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'UH004             ', N'M25       ', N'General Ledger Module                                                                                                   ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'UH004             ', N'M28       ', N'General Settings                                                                                                        ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'UH004             ', N'M2        ', N'General Setup                                                                                                           ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'UH004             ', N'M32       ', N'Generate Enrollee ID Card                                                                                               ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'UH004             ', N'M7        ', N'HCP Payment Register/Vetting                                                                                            ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'UH004             ', N'M6        ', N'Hospital Information                                                                                                    ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'UH004             ', N'M11       ', N'Job Appraisal                                                                                                           ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'UH004             ', N'M12       ', N'Leave Management                                                                                                        ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'UH004             ', N'M27       ', N'List Reports                                                                                                            ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'UH004             ', N'M3        ', N'Online Backup/Restore                                                                                                   ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'UH004             ', N'M17       ', N'Opening Balance                                                                                                         ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'UH004             ', N'M5        ', N'Organization information                                                                                                ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'UH004             ', N'M23       ', N'Payable/Creditors Module                                                                                                ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'UH004             ', N'M8        ', N'Payment Approvals / History                                                                                             ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'UH004             ', N'M20       ', N'Payroll Process                                                                                                         ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'UH004             ', N'M22       ', N'Receivable/Debtors Module                                                                                               ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'UH004             ', N'M13       ', N'Staff Birthday                                                                                                          ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'UH004             ', N'M10       ', N'Staff Information                                                                                                       ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'UH004             ', N'M9        ', N'Treatment Authorization                                                                                                 ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'UH004             ', N'M29       ', N'User Account Management                                                                                                 ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'UH004             ', N'M33       ', N'Utilization fees                                                                                                        ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'UH004             ', N'M1        ', N'Company Setup                                                                                                           ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'UH004             ', N'M2        ', N'General Setup                                                                                                           ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'UH004             ', N'M3        ', N'Online Backup/Restore                                                                                                   ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'UH004             ', N'M4        ', N'Enrollment information                                                                                                  ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'UH004             ', N'M5        ', N'Organization information                                                                                                ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'UH004             ', N'M6        ', N'Hospital Information                                                                                                    ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'UH004             ', N'M7        ', N'HCP Payment Register/Vetting                                                                                            ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'UH004             ', N'M8        ', N'Payment Approvals / History                                                                                             ', 1)
GO
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'UH004             ', N'M10       ', N'Staff Information                                                                                                       ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'UH004             ', N'M9        ', N'Treatment Authorization                                                                                                 ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'UH004             ', N'M11       ', N'Job Appraisal                                                                                                           ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'UH004             ', N'M12       ', N'Leave Management                                                                                                        ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'UH004             ', N'M13       ', N'Staff Birthday                                                                                                          ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'UH004             ', N'M14       ', N'Account Main Menu                                                                                                       ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'UH004             ', N'M15       ', N'Chart of Accounts                                                                                                       ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'UH004             ', N'M16       ', N'Accounting Period Setup                                                                                                 ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'UH004             ', N'M17       ', N'Opening Balance                                                                                                         ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'UH004             ', N'M18       ', N'Bank Setup                                                                                                              ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'UH004             ', N'M19       ', N'Account Group Setup                                                                                                     ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'UH004             ', N'M20       ', N'Payroll Process                                                                                                         ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'UH004             ', N'M21       ', N'Fixed Asset                                                                                                             ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'UH004             ', N'M22       ', N'Receivable/Debtors Module                                                                                               ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'UH004             ', N'M23       ', N'Payable/Creditors Module                                                                                                ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'UH004             ', N'M25       ', N'General Ledger Module                                                                                                   ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'UH004             ', N'M26       ', N'Detail Report Dailog                                                                                                    ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'UH004             ', N'M27       ', N'List Reports                                                                                                            ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'UH004             ', N'M28       ', N'General Settings                                                                                                        ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'UH004             ', N'M29       ', N'User Account Management                                                                                                 ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'UH004             ', N'M30       ', N'Audit Trail Settings                                                                                                    ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'UH004             ', N'M31       ', N'Download/Upload Utility                                                                                                 ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'UH004             ', N'M32       ', N'Generate Enrollee ID Card                                                                                               ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'UH004             ', N'M33       ', N'Utilization fees                                                                                                        ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'UH005             ', N'M1        ', N'Company Setup                                                                                                           ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'UH005             ', N'M2        ', N'General Setup                                                                                                           ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'UH005             ', N'M3        ', N'Online Backup/Restore                                                                                                   ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'UH005             ', N'M4        ', N'Enrollment information                                                                                                  ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'UH005             ', N'M5        ', N'Organization information                                                                                                ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'UH005             ', N'M6        ', N'Hospital Information                                                                                                    ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'UH005             ', N'M7        ', N'HCP Payment Register/Vetting                                                                                            ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'UH005             ', N'M8        ', N'Payment Approvals / History                                                                                             ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'UH005             ', N'M10       ', N'Staff Information                                                                                                       ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'UH005             ', N'M9        ', N'Treatment Authorization                                                                                                 ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'UH005             ', N'M11       ', N'Job Appraisal                                                                                                           ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'UH005             ', N'M12       ', N'Leave Management                                                                                                        ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'UH005             ', N'M13       ', N'Staff Birthday                                                                                                          ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'UH005             ', N'M14       ', N'Account Main Menu                                                                                                       ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'UH005             ', N'M15       ', N'Chart of Accounts                                                                                                       ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'UH005             ', N'M16       ', N'Accounting Period Setup                                                                                                 ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'UH005             ', N'M17       ', N'Opening Balance                                                                                                         ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'UH005             ', N'M18       ', N'Bank Setup                                                                                                              ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'UH005             ', N'M19       ', N'Account Group Setup                                                                                                     ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'UH005             ', N'M20       ', N'Payroll Process                                                                                                         ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'UH005             ', N'M21       ', N'Fixed Asset                                                                                                             ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'UH005             ', N'M22       ', N'Receivable/Debtors Module                                                                                               ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'UH005             ', N'M23       ', N'Payable/Creditors Module                                                                                                ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'UH005             ', N'M25       ', N'General Ledger Module                                                                                                   ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'UH005             ', N'M26       ', N'Detail Report Dailog                                                                                                    ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'UH005             ', N'M27       ', N'List Reports                                                                                                            ', 1)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'UH005             ', N'M28       ', N'General Settings                                                                                                        ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'UH005             ', N'M29       ', N'User Account Management                                                                                                 ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'UH005             ', N'M30       ', N'Audit Trail Settings                                                                                                    ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'UH005             ', N'M31       ', N'Download/Upload Utility                                                                                                 ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'UH005             ', N'M32       ', N'Generate Enrollee ID Card                                                                                               ', 0)
INSERT [dbo].[usersmenu] ([userid], [menucode], [menuname], [available]) VALUES (N'UH005             ', N'M33       ', N'Utilization fees                                                                                                        ', 0)
