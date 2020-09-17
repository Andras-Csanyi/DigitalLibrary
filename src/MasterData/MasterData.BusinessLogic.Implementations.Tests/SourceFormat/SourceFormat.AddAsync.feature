Feature: AddAsync

  As data structure owner and manager
  I need functionality
  Which provides me the ability to
  Build and Manage SourceFormats

  Scenario: Adds a SourceFormat when the newly added SourceFormat doesn't have RootDimensionStructure
    Given there is a SourceFormat without RootDimensionStructure
    When saving SourceFormat
    And it returns with the newly added SourceFormat
    Then the returned SourceFormat is not null
    And the returned SourceFormat's id should not be zero
    And the returned SourceFormat's name equals to the original's name
    And the returned SourceFormat's description equals to the original's description
    And the returned SourceFormat's is active value equals to the original's is active value

  Scenario: Adds a SourceFormat when the newly added SourceFormat has new RootDimensionStructure without dimension
  tree
    Given there is a SourceFormat without RootDimensionStructure
    And there is a DimensionStructure
    And DimensionStructure is RootDimensionStructure of SourceFormat
    When SourceFormat is saved
    And it returns with the newly added SourceFormat
    Then the returned SourceFormat is not null
    And the returned SourceFormat's id should not be zero
    And the returned SourceFormat's name equals to the original's name
    And the returned SourceFormat's description equals to the original's description
    And the returned SourceFormat's is active value equals to the original's is active value
    And the returned SourceFormat's RootDimensionStructure is not null
    And the returned SourceFormat's RootDimensionStructure Id is not zero
    And the returned SourceFormat's RootDimensionStructure's name equals to original's name
    And the returned SourceFormat's RootDimensionStructure's desc equals to original's desc
    And the returned SourceFormat's RootDimensionStructure's is active equals to original's is active

  Scenario: Adds a SourceFormat when RootDimensionStructure an already existing DimensionStructure
    Given there is a SourceFormat without RootDimensionStructure
    And there is a DimensionStructure
    And DimensionStructure is already stored in database
    And DimensionStructure is RootDimensionStructure of SourceFormat
    When SourceFormat is saved
    And it returns with the newly added SourceFormat
    Then the returned SourceFormat is not null
    And the returned SourceFormat's id should not be zero
    And the returned SourceFormat's name equals to the original's name
    And the returned SourceFormat's description equals to the original's description
    And the returned SourceFormat's is active value equals to the original's is active value
    And the returned SourceFormat's RootDimensionStructure is not null
    And the returned SourceFormat's RootDimensionStructure Id is not zero
    And the returned SourceFormat's RootDimensionStructure's name equals to original's name
    And the returned SourceFormat's RootDimensionStructure's desc equals to original's desc
    And the returned SourceFormat's RootDimensionStructure's is active equals to original's is active

  Scenario: Adds a SourceFormat when RootDimensionStructure an already existing DimensionStructure with connection
  to other SourceFormat
    Given there is a SourceFormat without RootDimensionStructure
    And there is a DimensionStructure
    And DimensionStructure is already stored in database
    And Dimensionstructure is already has connection to other SourceFormat
    And DimensionStructure is RootDimensionStructure of SourceFormat
    When SourceFormat is saved
    And it returns with the newly added SourceFormat
    Then the returned SourceFormat is not null
    And the returned SourceFormat's id should not be zero
    And the returned SourceFormat's name equals to the original's name
    And the returned SourceFormat's description equals to the original's description
    And the returned SourceFormat's is active value equals to the original's is active value
    And the returned SourceFormat's RootDimensionStructure is not null
    And the returned SourceFormat's RootDimensionStructure Id is not zero
    And the returned SourceFormat's RootDimensionStructure's name equals to original's name
    And the returned SourceFormat's RootDimensionStructure's desc equals to original's desc
    And the returned SourceFormat's RootDimensionStructure's is active equals to original's is active

  Scenario: Adds a SourceFormat when RootDimensionStructure has a single ChildDimensionStructure

  Scenario: Adds a SourceFormat when RootDimensionStructure has a single already existing ChildDimensionStructure

  Scenario: Adds a SourceFormat when RootDimensionStructure has a single already existing ChildDimensionStructure
  with connection to other SourceFormat as RootDimensionStructure

  Scenario: Adds a SourceFormat when RootDimensionStructure has a single already existing ChildDimensionStructure
  with connection to other SourceFormat as ChildDimensionStructure

  Scenario: Adds a SourceFormat when RootDimensionStructure has multiple ChildDimensionStructures and one of them is
  new the other one existing without connections

  Scenario: Adds a SourceFormat when RootDimensionStructure has multiple ChildDimensionStructures and one of them is
  new the other one existing with connection to other SourceFormat as RootDimensionStructure

  Scenario: Adds a SourceFormat when RootDimensionStructure has multiple ChildDimensionStructures and one of them is
  new the other one existing with connection to other SourceFormat as ChildDimensionStructure

  Scenario: Adds a SourceFormat when RootDimensionStructure has a single ChildDimensionStructure on the second level as new

  Scenario: Adds a SourceFormat when RootDimensionStructure has a single ChildDimensionStructure on the second level without
  connections

  Scenario: Adds a SourceFormat when RootDimensionStructure has a single ChildDimensionStructure on the second level with
  connection to other SourceFormats as RootDimensionStructure

  Scenario: Adds a SourceFormat when RootDimensionStructure has a single ChildDimensionStructure on the second level with
  connection to other SourceFormats as ChildDimensionStructure

  Scenario: Adds a SourceFormat when RootDimensionStructure has multiple ChildDimensionStructures on the second level
  and both of them are new

  Scenario: Adds a SourceFormat when RootDimensionStructure has multiple ChildDimensionStructures on the second level
  and one of them is new the other one has already existing

  Scenario: Adds a SourceFormat when RootDimensionStructure has multiple ChildDimensionStructures on the second level
  and one of them is new the other one has already existing with connection to other SourceFormat as
  ChildDimensionStructure

  Scenario: Adds a SourceFormat when RootDimensionStructure has multiple ChildDimensionStructures on the second level
  and one of them is new the other one has already existing with connection to other SourceFormat as
  RootDimensionStructure

  Scenario: Adds a SourceFormat when RootDimensionStructure has multiple ChildDimensionStructures on the second level
  and one of them is new the other one has already existing with connection to other SourceFormat as
  ChildDimensionStructure

  Scenario: Adds a SourceFormat when RootDimensionStructure has multiple ChildDimensionStructures on the second level
  and both of them existing

  Scenario: Adds a SourceFormat when RootDimensionStructure has multiple ChildDimensionStructures on the second level
  and both of them existing one of them has connection to other SourceFormat as ChildDimensionStructure and the other
  one has connection to other SourceFormat as RootDimensionStructure

  Scenario: Adds a SourceFormat when RootDimensionStructure has a single ChildDimensionStructure on the third level as
  new

  Scenario: Adds a SourceFormat when RootDimensionStructure has a single ChildDimensionStructure on the third level
  without   connections

  Scenario: Adds a SourceFormat when RootDimensionStructure has a single ChildDimensionStructure on the third level with
  connection to other SourceFormats as RootDimensionStructure

  Scenario: Adds a SourceFormat when RootDimensionStructure has a single ChildDimensionStructure on the third level with
  connection to other SourceFormats as ChildDimensionStructure

  Scenario: Adds a SourceFormat when RootDimensionStructure has multiple ChildDimensionStructures on the third level
  and both of them are new

  Scenario: Adds a SourceFormat when RootDimensionStructure has multiple ChildDimensionStructures on the third level
  and one of them is new the other one has already existing

  Scenario: Adds a SourceFormat when RootDimensionStructure has multiple ChildDimensionStructures on the third level
  and one of them is new the other one has already existing with connection to other SourceFormat as
  ChildDimensionStructure

  Scenario: Adds a SourceFormat when RootDimensionStructure has multiple ChildDimensionStructures on the third level
  and one of them is new the other one has already existing with connection to other SourceFormat as
  RootDimensionStructure

  Scenario: Adds a SourceFormat when RootDimensionStructure has multiple ChildDimensionStructures on the third level
  and one of them is new the other one has already existing with connection to other SourceFormat as
  ChildDimensionStructure

  Scenario: Adds a SourceFormat when RootDimensionStructure has multiple ChildDimensionStructures on the third level
  and both of them existing

  Scenario: Adds a SourceFormat when RootDimensionStructure has multiple ChildDimensionStructures on the third level
  and both of them existing one of them has connection to other SourceFormat as ChildDimensionStructure and the other
  one has connection to other SourceFormat as RootDimensionStructure

  Scenario: Adds a SourceFormat when RootDimensionStructure has multiple ChildDimensionStructures on the first
  level and both of them are new and there are multiple DimensionStructures on the second level both of them are
  new and multiple DimensionStructures on the third level both of them are new

  Scenario: Adds a SourceFormat when RootDimensionStructure has multiple ChildDimensionStructures on the first
  level and both of them are existing and there are multiple DimensionStructures on the second level both of them are
  existing and multiple DimensionStructures on the third level both of them are existing

  Scenario: Adds a SourceFormat when RootDimensionStructure has multiple ChildDimensionStructures on the first
  level and both of them have connection to other SourceFormats as ChildDimensions and there are multiple 
  DimensionStructures on the second level both of them have connection to other SourceFormats as 
  ChildDimensionStructure and multiple DimensionStructures on the third level both of them have connection to other 
  SourceFormat as ChildDimensionStructure