Feature: AddAsync

  As data structure owner and manager
  I need functionality
  Which provides me the ability to
  Build and Manage SourceFormats

#  Scenario: Adds a SourceFormat when the newly added SourceFormat doesn't have RootDimensionStructure
#    Given there is a SourceFormat without RootDimensionStructure
#    When saving SourceFormat
#    And it returns with the newly added SourceFormat
#    Then the returned SourceFormat is not null
#    And the returned SourceFormat's id should not be zero
#    And the returned SourceFormat's name equals to the original's name
#    And the returned SourceFormat's description equals to the original's description
#    And the returned SourceFormat's is active value equals to the original's is active value
#
#  Scenario: Adds a SourceFormat when the newly added SourceFormat has new RootDimensionStructure without dimension
#  tree
#    Given there is a SourceFormat without RootDimensionStructure
#    And there is a DimensionStructure
#    And DimensionStructure is RootDimensionStructure of SourceFormat
#    When SourceFormat is saved
#    And it returns with the newly added SourceFormat
#    Then the returned SourceFormat is not null
#    And the returned SourceFormat's id should not be zero
#    And the returned SourceFormat's name equals to the original's name
#    And the returned SourceFormat's description equals to the original's description
#    And the returned SourceFormat's is active value equals to the original's is active value
#    And the returned SourceFormat's RootDimensionStructure is not null
#    And the returned SourceFormat's RootDimensionStructure Id is not zero
#    And the returned SourceFormat's RootDimensionStructure's name equals to original's name
#    And the returned SourceFormat's RootDimensionStructure's desc equals to original's desc
#    And the returned SourceFormat's RootDimensionStructure's is active equals to original's is active
#
#  Scenario: Adds a SourceFormat when RootDimensionStructure an already existing DimensionStructure
#    Given there is a SourceFormat without RootDimensionStructure
#    And there is a DimensionStructure
#    And DimensionStructure is already stored in database
#    And DimensionStructure is RootDimensionStructure of SourceFormat
#    When SourceFormat is saved
#    And it returns with the newly added SourceFormat
#    Then the returned SourceFormat is not null
#    And the returned SourceFormat's id should not be zero
#    And the returned SourceFormat's name equals to the original's name
#    And the returned SourceFormat's description equals to the original's description
#    And the returned SourceFormat's is active value equals to the original's is active value
#    And the returned SourceFormat's RootDimensionStructure is not null
#    And the returned SourceFormat's RootDimensionStructure Id is not zero
#    And the returned SourceFormat's RootDimensionStructure's name equals to original's name
#    And the returned SourceFormat's RootDimensionStructure's desc equals to original's desc
#    And the returned SourceFormat's RootDimensionStructure's is active equals to original's is active
#
#  Scenario: Adds a SourceFormat when RootDimensionStructure an already existing DimensionStructure with connection
#  to other SourceFormat
#    Given there is a SourceFormat without RootDimensionStructure
#    And there is a DimensionStructure named as RootDimensionStructure
#    And DimensionStructure is already stored in database
#    And Dimensionstructure is already has connection to other SourceFormat
#    And DimensionStructure is RootDimensionStructure of SourceFormat
#    When SourceFormat is saved
#    And it returns with the newly added SourceFormat
#    Then the returned SourceFormat is not null
#    And the returned SourceFormat's id should not be zero
#    And the returned SourceFormat's name equals to the original's name
#    And the returned SourceFormat's description equals to the original's description
#    And the returned SourceFormat's is active value equals to the original's is active value
#    And the returned SourceFormat's RootDimensionStructure is not null
#    And the returned SourceFormat's RootDimensionStructure Id is not zero
#    And the returned SourceFormat's RootDimensionStructure's name equals to original's name
#    And the returned SourceFormat's RootDimensionStructure's desc equals to original's desc
#    And the returned SourceFormat's RootDimensionStructure's is active equals to original's is active
#
#  Scenario: Adds a SourceFormat when RootDimensionStructure has a single new ChildDimensionStructure
#    Given there is a SourceFormat without RootDimensionStructure
#    And there is a DimensionStructure named as Root
#    And there is a DimensionStructure named as Child1
#    And RootDimensionStructure has ChildDimensionStructure at the first level in the DimensionStructure tree
#    And RootDimensionStructure is the RootDimensionStructure of SourceFormat
#    When SourceFormat is saved
#    And it returns with the newly added SourceFormat
#    Then the returned SourceFormat is not null
#    And the returned SourceFormat's id should not be zero
#    And the returned SourceFormat's name equals to the original's name
#    And the returned SourceFormat's description equals to the original's description
#    And the returned SourceFormat's is active value equals to the original's is active value
#    And the returned SourceFormat's RootDimensionStructure is not null
#    And the returned SourceFormat's RootDimensionStructure Id is not zero
#    And the returned SourceFormat's RootDimensionStructure's name equals to original's name
#    And the returned SourceFormat's RootDimensionStructure's desc equals to original's desc
#    And the returned SourceFormat's RootDimensionStructure's is active equals to original's is active
#    And SF RootDS ChildDS collection length is not zero
#    And SF RootDS ChildDS collection has one element
#    And SF RootDS ChildDS collection's single element's id isn't zero
#    And SF RootDS ChildDS collection's single element's name equals to ChildDS name
#    And SF RootDS ChildDS collection's single element's desc equals to ChildDS desc
#
#  Scenario: Adds a SourceFormat when RootDimensionStructure has a single already existing ChildDimensionStructure
#    Given there is a SourceFormat without RootDimensionStructure called SF1
#    And there is a DimensionStructure named as Root
#    And there is a DimensionStructure named as Child1
#    And Child1 already stored in the database
#    And Root has Child1 at the first level in the DimensionStructure tree
#    And Root is the RootDimensionStructure of SourceFormat
#    When SourceFormat is saved
#    And it returns with the newly added SourceFormat
#    Then the returned SourceFormat is not null
#    And the returned SourceFormat's id should not be zero
#    And the returned SourceFormat's name equals to the original's name
#    And the returned SourceFormat's description equals to the original's description
#    And the returned SourceFormat's is active value equals to the original's is active value
#    And the returned SourceFormat's RootDimensionStructure is not null
#    And the returned SourceFormat's RootDimensionStructure Id is not zero
#    And the returned SourceFormat's RootDimensionStructure's name equals to original's name
#    And the returned SourceFormat's RootDimensionStructure's desc equals to original's desc
#    And the returned SourceFormat's RootDimensionStructure's is active equals to original's is active
#    And SF RootDS ChildDS collection length is not zero
#    And SF RootDS ChildDS collection has one element
#    And SF RootDS ChildDS collection's single element's id isn't zero
#    And SF RootDS ChildDS collection's single element's id eq to Child1 id
#    And SF RootDS ChildDS collection's single element's name equals to Child1 name
#    And SF RootDS ChildDS collection's single element's desc equals to Child1 desc
#
#  Scenario: Adds a SourceFormat when RootDimensionStructure has a single already existing ChildDimensionStructure
#  with connection to other SourceFormat as RootDimensionStructure
#
#    Given there is a SourceFormat without RootDimensionStructure called SF1
#    And there is a SourceFormat called SF2
#    And SF2 already stored in the database
#    And there is a DimensionStructure named as Root
#    And there is a DimensionStructure named as Child1
#    And Child1 already stored in the database
#    And Child1 is RootDS of SF2
#    And Root has Child1 at the first level in the DimensionStructure tree
#    And Root is the RootDimensionStructure of SourceFormat
#
#    When SourceFormat is saved
#    And it returns with the newly added SourceFormat
#
#    Then the returned SourceFormat is not null
#    And the returned SourceFormat's id should not be zero
#    And the returned SourceFormat's name equals to the original's name
#    And the returned SourceFormat's description equals to the original's description
#    And the returned SourceFormat's is active value equals to the original's is active value
#    And the returned SourceFormat's RootDimensionStructure is not null
#    And the returned SourceFormat's RootDimensionStructure Id is not zero
#    And the returned SourceFormat's RootDimensionStructure's name equals to original's name
#    And the returned SourceFormat's RootDimensionStructure's desc equals to original's desc
#    And the returned SourceFormat's RootDimensionStructure's is active equals to original's is active
#    And SF RootDS ChildDS collection length is not zero
#    And SF RootDS ChildDS collection has one element
#    And SF RootDS ChildDS collection's single element's id isn't zero
#    And SF RootDS ChildDS collection's single element's id eq to Child1 id
#    And SF RootDS ChildDS collection's single element's name equals to Child1 name
#    And SF RootDS ChildDS collection's single element's desc equals to Child1 desc
#    And SF RootDS ChildDS collection's single element's has SF2 where it is RootDS
#
#  Scenario: Adds a SourceFormat
#  when RootDimensionStructure has a single already existing ChildDimensionStructure
#  with connection to other SourceFormat as ChildDimensionStructure
#
#    Given there is a SourceFormat without RootDimensionStructure called SF1
#    And there is a DimensionStructure named as RootDS
#    And there is a DimensionStructure named as Child1
#    And there is a SourceFormat called SF2
#    And there is a DimensionStructure called SF2Root
#    And SF2Root is root dimension structure of SF2
#    And SF2 already stored in the database
#    And Child1 already stored in the database
#    And Child1 is Child of SF2Root
#    And RootDS has Child1 at the first level in the DimensionStructure tree
#    And RootDS is the RootDimensionStructure of SourceFormat
#
#    When SourceFormat is saved
#    And it returns with the newly added SourceFormat
#
#    Then the returned SourceFormat is not null
#    And the returned SourceFormat's id should not be zero
#    And the returned SourceFormat's name equals to the original's name
#    And the returned SourceFormat's description equals to the original's description
#    And the returned SourceFormat's is active value equals to the original's is active value
#    And the returned SourceFormat's RootDimensionStructure is not null
#    And the returned SourceFormat's RootDimensionStructure Id is not zero
#    And the returned SourceFormat's RootDimensionStructure's name equals to original's name
#    And the returned SourceFormat's RootDimensionStructure's desc equals to original's desc
#    And the returned SourceFormat's RootDimensionStructure's is active equals to original's is active
#    And SF1 RootDS Child1 collection length is not zero
#    And SF1 RootDS Child1 collection has one element
#    And SF1 RootDS Child1 collection's single element's id isn't zero
#    And SF1 RootDS Child1 collection's single element's id eq to Child1 id
#    And SF1 RootDS Child1 collection's single element's name equals to Child1 name
#    And SF1 RootDS Child1 collection's single element's desc equals to Child1 desc
#    And SF1 RootDS Child1 collection's single element's has other connections towards SF2Root
#    And SF2Root has Child1 as ChildDimensionStructure
#
#  Scenario: Adds a SourceFormat
#  when RootDimensionStructure has multiple ChildDimensionStructures
#  and one of them is new the other one existing without connections
#
#    Given there is a SourceFormat without RootDimensionStructure called SF1
#    And there is a DimensionStructure named as RootDS
#    And there is a DimensionStructure named as ChildNew
#    And there is a DimensionStructure named as ChildExisting
#    And ChildExisting is stored in the database
#    And ChildNew is child dimension structure of RootDS at first level
#    And ChildExisting is child dimension structure of RootDS at first level
#    And RootDS is root dimension structure of SF1
#
#    When SF1 is saved
#    And it returned with the newly added SourceFormat
#
#    Then result SF is not null
#    And result is type of SF
#    And result SF's Id is not zero
#    And result SF's Name equals to SF1's Name
#    And result SF's Desc equals to SF1's Desc
#    And result SF's IsActive equals to SF1's IsActive
#    And SF1's root dimension structure is not null
#    And SF1's root dimension structure is type of DimensionStructure
#    And result SF's root ds Id equals to RootDS Id
#    And result SF's root ds Name equals to RootDS Name
#    And result SF's root ds Desc equals to RootDS Desc
#    And result SF's root ds IsActive equals to RootDS IsActive
#    And result SF's root ds child collection is not null
#    And result SF's root ds child collection length is 2
#    And there is a child where Id is not zero
#    And there is a child where Name equals to ChildNew Name
#    And there is a child where Desc equals to ChildNew Desc
#    And there is a child where IsActive equals to ChildNew IsActive
#    And there is a child where Id equals to ChildExisting Id
#    And there is a child where Name equals to ChildExisting Name
#    And there is a child where Desc equals to ChildExisting Desc
#    And there is a child where IsActive equals to ChildExisting IsActive
#
#  Scenario: Adds a SourceFormat
#  when RootDimensionStructure has multiple ChildDimensionStructures
#  and one of them is new
#  the other one existing with connection to other SourceFormat as RootDimensionStructure
#
#    Given there is a SourceFormat without RootDimensionStructure called SF1
#    And there is a SourceFormat without RootDimensionStructure called SF2
#    And there is a DimensionStructure named as RootDS
#    And there is a DimensionStructure named as ChildNew
#    And there is a DimensionStructure named as ChildAndRootDS
#    And ChildAndRootDS is root ds of SF2
#    And ChildAndRootDS is stored in the database
#    And SF2 is stored in the database
#    And ChildNew is child dimension structure of RootDS at first level
#    And ChildAndRootDS is child dimension structure of RootDS at first level
#    And RootDS is root dimension structure of SF1
#
#    When SF1 is saved
#    And it returned with the newly added SourceFormat
#
#    Then result SF is not null
#    And result is type of SF
#    And result SF's Id is not zero
#    And result SF's Name equals to SF1's Name
#    And result SF's Desc equals to SF1's Desc
#    And result SF's IsActive equals to SF1's IsActive
#    And SF1's root dimension structure is not null
#    And SF1's root dimension structure is type of DimensionStructure
#    And result SF's root ds Id equals to RootDS Id
#    And result SF's root ds Name equals to RootDS Name
#    And result SF's root ds Desc equals to RootDS Desc
#    And result SF's root ds IsActive equals to RootDS IsActive
#    And result SF's root ds child collection is not null
#    And result SF's root ds child collection length is 2
#    And there is a child where Id is not zero
#    And there is a child where Name equals to ChildNew Name
#    And there is a child where Desc equals to ChildNew Desc
#    And there is a child where IsActive equals to ChildNew IsActive
#    And there is a child where Id equals to ChildAndRootDS Id
#    And there is a child where Name equals to ChildAndRootDS Name
#    And there is a child where Desc equals to ChildAndRootDS Desc
#    And there is a child where IsActive equals to ChildAndRootDS IsActive
#    And there is a child where Id eq ChildAndRootDS Id and child is root ds of SF2

  Scenario: Adds a SourceFormat
  when RootDimensionStructure has multiple ChildDimensionStructures
  and one of them is new
  the other one existing with connection to other SourceFormat as ChildDimensionStructure

    Given there is a domain object
      | Name | SF2          |
      | Type | SourceFormat |
    And there is a domain object
      | Name | SF2Root            |
      | Type | DimensionStructure |
    And there is a domain object
      | Name | ChildAndChildOfOther |
      | Type | DimensionStructure   |
    And add a domain object to another domain object's property
      | TargetDomainObjectName     | SF2                    |
      | TargetDomainObjectType     | SourceFormat           |
      | TargetDomainObjectPropName | RootDimensionStructure |
      | TargetDomainObjectSource   | Bag                    |
      | DomainObjectNameToBeAdded  | SF2Root                |
      | DomainObjectToBeAddedType  | DimensionStructure     |
      | DomainObjectSource         | Bag                    |
    And domain object is saved
      | DomainObjectType | SourceFormat |
      | DomainObjectName | SF2          |
      | ResultName       | SF2Result    |
    And sync test domain object
      | Type     | DimensionStructure         |
      | Name     | ChildAndChildOfOther       |
      | ResultId | ChildAndChildOfOtherResult |

    And there is a domain object
      | Name | SF1          |
      | Type | SourceFormat |
    And there is a domain object
      | Name | RootDs             |
      | Type | DimensionStructure |
    And there is a domain object
      | Name | ChildNew           |
      | Type | DimensionStructure |

    And SourceFormat RootDimensionStructure has a child DimensionStructure
      | ChildName                | ChildNew |
      | NodeName                 | RootDs   |
      | SourceFormatSource       | Bag      |
      | DimensionStructureSource | Bag      |
      | SourceFormatName         | SF1      |
    And SourceFormat RootDimensionStructure has a child DimensionStructure
      | ChildName                | ChildAndChildOfOther |
      | NodeName                 | RootDs               |
      | SourceFormatSource       | Bag                  |
      | DimensionStructureSource | Bag                  |
      | SourceFormatName         | SF1                  |
    And add a domain object to another domain object's property
      | TargetDomainObjectName     | SF1                    |
      | TargetDomainObjectType     | SourceFormat           |
      | TargetDomainObjectPropName | RootDimensionStructure |
      | TargetDomainObjectSource   | Bag                    |
      | DomainObjectNameToBeAdded  | RootDs                 |
      | DomainObjectToBeAddedType  | DimensionStructure     |
      | DomainObjectSource         | Bag                    |

    And domain object is saved
      | DomainObjectType | SourceFormat |
      | DomainObjectName | SF1          |
      | ResultId         | SF1Result    |

    Then <SF1Result> SourceFormat save result is not null
    And <SF1Result> SourceFormat result Id is not <0>
    And SourceFormat result property equals to
      | Name      | PropertyName | EqualsTo |
      | SF1Result | Name         | SF1      |
    And SourceFormat result property equals to
      | Name      | PropertyName | EqualsTo |
      | SF1Result | Desc         | SF1      |
    And SourceFormat result property equals to
      | Name      | PropertyName | EqualsTo |
      | SF1Result | IsActive     | SF1      |
    And SourceFormat result property is not null
      | Name      | PropertyName           |
      | SF1Result | RootDimensionStructure |
    And SourceFormat result's RootDimensionStructure property equals to
      | Name      | PropertyName | EqualsTo |
      | SF1Result | Id           | RootDs   |
    And SourceFormat result's RootDimensionStructure property equals to
      | Name      | PropertyName | EqualsTo |
      | SF1Result | Name         | RootDs   |
    And SourceFormat result's RootDimensionStructure property equals to
      | Name      | PropertyName | EqualsTo |
      | SF1Result | Desc         | RootDs   |
    And SourceFormat result's RootDimensionStructure property equals to
      | Name      | PropertyName | EqualsTo |
      | SF1Result | IsActive     | RootDs   |
    And <SF1Result> SourceFormat result's RootDimensionStructure ChildDimensionStructure is not null
    And <SF1Result> SourceFormat result's RootDimensionStructure ChildDimensionStructure length is <2>
    And SourceFormat result's DimensionStructureTree has DimensionStructure under given node
      | SourceFormatName | SF1Result            |
      | PropName         | Name                 |
      | Value            | ChildAndChildOfOther |
      | NodeName         | RootDs               |
    And SourceFormat result's DimensionStructureTree has DimensionStructure under given node
      | SourceFormatName | SF1Result |
      | PropName         | Name      |
      | Value            | ChildNew  |
      | NodeName         | RootDs    |
    And a DimensionStructure is child of multiple RootDimensionStructures
      | SourceFormatName | DimensionStructureName | LookupProp |
      | SF1Result        | ChildAndChildOfOther   | Name       |
      | SF2Result        | ChildAndChildOfOther   | Name       |

#  Scenario: Adds a SourceFormat when RootDimensionStructure has a single ChildDimensionStructure on the second level as new
#
#  Scenario: Adds a SourceFormat when RootDimensionStructure has a single ChildDimensionStructure on the second level without
#  connections
#
#  Scenario: Adds a SourceFormat when RootDimensionStructure has a single ChildDimensionStructure on the second level with
#  connection to other SourceFormats as RootDimensionStructure
#
#  Scenario: Adds a SourceFormat when RootDimensionStructure has a single ChildDimensionStructure on the second level with
#  connection to other SourceFormats as ChildDimensionStructure
#
#  Scenario: Adds a SourceFormat when RootDimensionStructure has multiple ChildDimensionStructures on the second level
#  and both of them are new
#
#  Scenario: Adds a SourceFormat when RootDimensionStructure has multiple ChildDimensionStructures on the second level
#  and one of them is new the other one has already existing
#
#  Scenario: Adds a SourceFormat when RootDimensionStructure has multiple ChildDimensionStructures on the second level
#  and one of them is new the other one has already existing with connection to other SourceFormat as
#  ChildDimensionStructure
#
#  Scenario: Adds a SourceFormat when RootDimensionStructure has multiple ChildDimensionStructures on the second level
#  and one of them is new the other one has already existing with connection to other SourceFormat as
#  RootDimensionStructure
#
#  Scenario: Adds a SourceFormat when RootDimensionStructure has multiple ChildDimensionStructures on the second level
#  and one of them is new the other one has already existing with connection to other SourceFormat as
#  ChildDimensionStructure
#
#  Scenario: Adds a SourceFormat when RootDimensionStructure has multiple ChildDimensionStructures on the second level
#  and both of them existing
#
#  Scenario: Adds a SourceFormat when RootDimensionStructure has multiple ChildDimensionStructures on the second level
#  and both of them existing one of them has connection to other SourceFormat as ChildDimensionStructure and the other
#  one has connection to other SourceFormat as RootDimensionStructure
#
#  Scenario: Adds a SourceFormat when RootDimensionStructure has a single ChildDimensionStructure on the third level as
#  new
#
#  Scenario: Adds a SourceFormat when RootDimensionStructure has a single ChildDimensionStructure on the third level
#  without   connections
#
#  Scenario: Adds a SourceFormat when RootDimensionStructure has a single ChildDimensionStructure on the third level with
#  connection to other SourceFormats as RootDimensionStructure
#
#  Scenario: Adds a SourceFormat when RootDimensionStructure has a single ChildDimensionStructure on the third level with
#  connection to other SourceFormats as ChildDimensionStructure
#
#  Scenario: Adds a SourceFormat when RootDimensionStructure has multiple ChildDimensionStructures on the third level
#  and both of them are new
#
#  Scenario: Adds a SourceFormat when RootDimensionStructure has multiple ChildDimensionStructures on the third level
#  and one of them is new the other one has already existing
#
#  Scenario: Adds a SourceFormat when RootDimensionStructure has multiple ChildDimensionStructures on the third level
#  and one of them is new the other one has already existing with connection to other SourceFormat as
#  ChildDimensionStructure
#
#  Scenario: Adds a SourceFormat when RootDimensionStructure has multiple ChildDimensionStructures on the third level
#  and one of them is new the other one has already existing with connection to other SourceFormat as
#  RootDimensionStructure
#
#  Scenario: Adds a SourceFormat when RootDimensionStructure has multiple ChildDimensionStructures on the third level
#  and one of them is new the other one has already existing with connection to other SourceFormat as
#  ChildDimensionStructure
#
#  Scenario: Adds a SourceFormat when RootDimensionStructure has multiple ChildDimensionStructures on the third level
#  and both of them existing
#
#  Scenario: Adds a SourceFormat when RootDimensionStructure has multiple ChildDimensionStructures on the third level
#  and both of them existing one of them has connection to other SourceFormat as ChildDimensionStructure and the other
#  one has connection to other SourceFormat as RootDimensionStructure
#
#  Scenario: Adds a SourceFormat when RootDimensionStructure has multiple ChildDimensionStructures on the first
#  level and both of them are new and there are multiple DimensionStructures on the second level both of them are
#  new and multiple DimensionStructures on the third level both of them are new
#
#  Scenario: Adds a SourceFormat when RootDimensionStructure has multiple ChildDimensionStructures on the first
#  level and both of them are existing and there are multiple DimensionStructures on the second level both of them are
#  existing and multiple DimensionStructures on the third level both of them are existing
#
#  Scenario: Adds a SourceFormat when RootDimensionStructure has multiple ChildDimensionStructures on the first
#  level and both of them have connection to other SourceFormats as ChildDimensions and there are multiple
#  DimensionStructures on the second level both of them have connection to other SourceFormats as
#  ChildDimensionStructure and multiple DimensionStructures on the third level both of them have connection to other
#  SourceFormat as ChildDimensionStructure