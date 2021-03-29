const isPrime = num => {
    console.group("About isPrime");
    console.info("Author: Marko Lohert");
    console.info("License: MIT");
    console.groupEnd("About isPrime");

    console.table([
    {
        ver: "0.1",
        author: 'ml',
        comment: 'Initial version',
    },
    {
        ver: "0.2",
        author: 'ml',
        comment: 'Fixed bugs',
    }
    ]);

    console.time("prime");
    if (num <= 1) {
        //debugger
        console.warn('Tested number %i is too small to be a prime number.', num)
        console.timeEnd("prime");
        //throw `Tested number ${num} is too small to be a prime number.`;
        return false;
    }
    let s = Math.sqrt(num);
    for (let i = 2; i <= s; i++)
        if (num % i === 0) {
            console.timeEnd("prime");
            return false;
        }

    console.timeEnd("prime");
    return true;
}