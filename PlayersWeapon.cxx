#include <iostream>
#include <map>
#include <iomanip>
#include <string>
#include <algorithm>
#include <limits>

using namespace std;

// Structure for chemical element data
struct Element {
    string symbol;
    int atomic_number;
    double atomic_mass;
};

// Database of elements
const map<string, Element> elements = {
    {"hydrogen", {"H", 1, 1.008}},
    {"helium", {"He", 2, 4.0026}},
    {"carbon", {"C", 6, 12.011}},
    {"nitrogen", {"N", 7, 14.007}},
    {"oxygen", {"O", 8, 15.999}},
    {"sodium", {"Na", 11, 22.990}},
    {"chlorine", {"Cl", 17, 35.45}},
    {"iron", {"Fe", 26, 55.845}},
    {"copper", {"Cu", 29, 63.546}},
    {"gold", {"Au", 79, 196.9665}},
    {"silver", {"Ag", 47, 107.8682}},
    {"aluminum", {"Al", 13, 26.9815}},
    {"neon", {"Ne", 10, 20.1797}},
    {"argon", {"Ar", 18, 39.948}},
    {"krypton", {"Kr", 36, 83.798}},
    {"xenon", {"Xe", 54, 131.293}},
    {"radon", {"Rn", 86, 222.018}}
};

// Convert string to lowercase
string toLower(string str) {
    transform(str.begin(), str.end(), str.begin(), ::tolower);
    return str;
}

// Display all available elements
void listAvailableElements() {
    cout << "\nAvailable Elements:\n";
    for (const auto& pair : elements) {
        cout << "  - " << pair.first << " (" << pair.second.symbol << ")\n";
    }
    cout << endl;
}

// Calculate molecular mass of a compound from two elements and their counts
double calculateCompoundMass(const string& e1, int c1, const string& e2, int c2) {
    string name1 = toLower(e1);
    string name2 = toLower(e2);

    if (elements.count(name1) && elements.count(name2)) {
        const Element& el1 = elements.at(name1);
        const Element& el2 = elements.at(name2);
        return (el1.atomic_mass * c1) + (el2.atomic_mass * c2);
    }
    return -1.0;  // Indicate error if element not found
}

// Display Fibonacci series of n terms
void fibonacci(int n) {
    if (n <= 0) {
        cout << "Please enter a positive integer greater than zero for Fibonacci terms.\n";
        return;
    }

    int a = 0, b = 1;
    cout << "Fibonacci Series: ";
    for (int i = 0; i < n; i++) {
        cout << a << (i < n - 1 ? " " : "\n");
        int next = a + b;
        a = b;
        b = next;
    }
}

// Simulated hacking tool interface for guessing password
void hackingTool() {
    const string targetFile = "<data><user>admin</user><password>justice2025</password></data>";
    string guess;
    int attempts = 3;

    cout << "\n=== XSL HACKING TOOL INTERFACE ===\n";
    cout << "Encrypted File: " << targetFile << "\n";
    cout << "Your task: Guess the admin password.\n";

    while (attempts > 0) {
        cout << "Enter password guess (" << attempts << " attempt" << (attempts > 1 ? "s" : "") << " left): ";
        getline(cin, guess);

        if (guess == "justice2025") {
            cout << "\nACCESS GRANTED. Decryption Successful.\n";
            cout << "[Extracted XML Data]\n";
            cout << "  User: admin\n";
            cout << "  Password: justice2025\n";
            return;
        } else {
            cout << "ACCESS DENIED.\n";
            attempts--;
        }
    }

    cout << "\nSYSTEM LOCKED. Intrusion Detected.\n";
}

// Utility function to safely read an integer with validation
int readInt(const string& prompt) {
    int value;
    while (true) {
        cout << prompt;
        if (cin >> value) {
            cin.ignore(numeric_limits<streamsize>::max(), '\n'); // discard rest of line
            return value;
        } else {
            cout << "Invalid input. Please enter a valid integer.\n";
            cin.clear();
            cin.ignore(numeric_limits<streamsize>::max(), '\n');
        }
    }
}

int main() {
    int choice;

    do {
        cout << "\n=== MAIN MENU ===\n";
        cout << "1. List Elements\n";
        cout << "2. Calculate Compound Mass\n";
        cout << "3. Fibonacci Series\n";
        cout << "4. Hacking Tool\n";
        cout << "0. Exit\n";
        choice = readInt("Enter your choice: ");

        switch (choice) {
            case 1:
                listAvailableElements();
                break;

            case 2: {
                string element1, element2;
                int count1, count2;

                cout << "Enter the first element name: ";
                getline(cin, element1);

                count1 = readInt("Enter number of atoms for " + element1 + ": ");
                if (count1 <= 0) {
                    cout << "Number of atoms must be positive.\n";
                    break;
                }

                cout << "Enter the second element name: ";
                getline(cin, element2);

                count2 = readInt("Enter number of atoms for " + element2 + ": ");
                if (count2 <= 0) {
                    cout << "Number of atoms must be positive.\n";
                    break;
                }

                double mass = calculateCompoundMass(element1, count1, element2, count2);
                if (mass < 0) {
                    cout << "\nError: One or both elements not found in the database.\n";
                } else {
                    cout << fixed << setprecision(4);
                    cout << "\nCompound: " << count1 << " " << toLower(element1)
                         << " + " << count2 << " " << toLower(element2) << endl;
                    cout << "Estimated Molecular Mass: " << mass << " g/mol\n";
                }
                break;
            }

            case 3: {
                int n = readInt("Enter number of Fibonacci terms: ");
                fibonacci(n);
                break;
            }

            case 4:
                hackingTool();
                break;

            case 0:
                cout << "Exiting program. Goodbye!\n";
                break;

            default:
                cout << "Invalid choice. Please try again.\n";
        }

    } while (choice != 0);

    return 0;
}
