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
      