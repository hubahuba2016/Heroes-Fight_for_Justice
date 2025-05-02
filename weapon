#include <iostream>
#include <complex>
#include <vector>
#include <limits>
#include <stdexcept>

// Render Mandelbrot set as ASCII
void render_mandelbrot(int width = 80, int height = 40, int max_iter = 100) {
    if (width <= 0 || height <= 0 || max_iter <= 0) {
        throw std::invalid_argument("Width, height, and max_iter must be positive.");
    }

    constexpr double x_min = -2.0, x_max = 1.0, y_min = -1.0, y_max = 1.0;
    const std::string gradient = " .:-=+*%@#";

    for (int j = 0; j < height; ++j) {
        double y = y_min + (y_max - y_min) * j / (height - 1.0);
        for (int i = 0; i < width; ++i) {
            double x = x_min + (x_max - x_min) * i / (width - 1.0);
            std::complex<double> c(x, y), z(0);
            int iter = 0;
            while (std::abs(z) <= 2.0 && iter < max_iter) {
                z = z * z + c;
                ++iter;
            }
            char ch = (iter == max_iter) ? gradient.back() : gradient[iter * gradient.size() / max_iter];
            std::cout << ch;
        }
        std::cout << '\n';
    }
}

// Generate Fibonacci sequence
std::vector<unsigned long long> generate_fibonacci(int count) {
    if (count < 0) {
        throw std::invalid_argument("Count must be non-negative.");
    }

    std::vector<unsigned long long> fib;
    if (count > 0) fib.push_back(0);
    if (count > 1) fib.push_back(1);

    for (int i = 2; i < count; ++i) {
        fib.push_back(fib[i - 1] + fib[i - 2]);
    }

    return fib;
}

// Clear bad input
void clear_input() {
    std::cin.clear();
    std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
}

// Main menu
int main() {
    std::cout << "=== Mandelbrot and Fibonacci Viewer ===\n";
    std::cout << "1. Display Mandelbrot Set\n";
    std::cout << "2. Display Fibonacci Sequence\n";
    std::cout << "Choose an option (1 or 2): ";

    int choice;
    std::cin >> choice;

    if (std::cin.fail()) {
        clear_input();
        std::cerr << "Invalid input. Exiting.\n";
        return 1;
    }

    try {
        if (choice == 1) {
            int width = 80, height = 40, max_iter = 100;
            std::cout << "Enter width, height, and max iterations (default: 80 40 100): ";
            std::cin >> width >> height >> max_iter;

            if (std::cin.fail()) {
                clear_input();
                std::cout << "Invalid input. Using defaults.\n";
                width = 80, height = 40, max_iter = 100;
            }

            std::cout << "\nRendering Mandelbrot Set...\n";
            render_mandelbrot(width, height, max_iter);

        } else if (choice == 2) {
            int count;
            std::cout << "Enter number of Fibonacci terms: ";
            std::cin >> count;

            if (std::cin.fail()) {
                clear_input();
                std::cerr << "Invalid number. Exiting.\n";
                return 1;
            }

            auto fib = generate_fibonacci(count);
            std::cout << "\nFibonacci Sequence (" << count << " terms):\n";
            for (auto n : fib) std::cout << n << ' ';
            std::cout << '\n';

        } else {
            std::cerr << "Invalid option. Exiting.\n";
        }
    } catch (const std::exception& e) {
        std::cerr << "Error: " << e.what() << '\n';
    }

    return 0;
}