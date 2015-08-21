Feature: FibonacciCalculations
	In order to verify Fibonacci calculations
	As a user
	I want to determine the nth Fibonacci number

Scenario: Get Nth Fibonacci number
	Given I enter 50 into the Fibonacci calculator
	When I press the submit button
	Then the result should be 12586269025

Scenario: Get Nth Fibonacci number for multiple values
	Given the following set of data
	| n   | Result                                                                                                    |
	| 0   | 0                                                                                                         |
	| 1   | 1                                                                                                         |
	| 2   | 1                                                                                                         |
	| 3   | 2                                                                                                         |
	| 50  | 12586269025                                                                                               |
	| 300 | 222232244629420445529739893461909967206666939096499764990979600                                           |
	| 500 | 139423224561697880139724382870407283950070256587697307264108962948325571622863290691557658876222521294125 |
	Given I enter n into the Fibonacci calculator
	When I press the submit button
	Then the result should match Result