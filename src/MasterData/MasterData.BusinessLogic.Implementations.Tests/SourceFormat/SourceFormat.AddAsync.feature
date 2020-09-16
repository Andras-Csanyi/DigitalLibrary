Feature: AddAsync
  
  Scenario: Adds a SourceFormat when the newly added SourceFormat doesn't have RootDimensionStructure
    Given there is a SourceFormat without RootDimensionStructure
    When saving SourceFormat
    And it returns with the newly added SourceFormat
    Then the returned SourceFormat is not null
    And the returned SourceFormat's id should not be zero
    And the returned SourceFormat's name equals to the original's name
    And the returned SourceFormat's description equals to the original's description
    And the returned SourceFormat's is active value equals to the original's is active value