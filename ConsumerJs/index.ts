process.env["NODE_TLS_REJECT_UNAUTHORIZED"] = '0';
import buildQuery from 'odata-query';
import fetch from 'node-fetch';

async function getEvents(name: string, date: Date) {  
    // and example
    const query = buildQuery({ filter: [`startswith(Name, '${name}')`, { Date: { gt: date}}]})
    const url = `http://localhost:5000/odata/event${query}`;
    console.log(`calling ${url}`)
    const res = await fetch(url);
    return res.json();
}

getEvents('Event', new Date()).then((res) => {
    console.log(res);
});

