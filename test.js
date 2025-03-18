import http from 'k6/http';
import { sleep } from 'k6';

export const options = {
    vus: 100,           // 10명의 동시 사용자
    duration: '10s',    // 10초
};

export default function () {
    // 동기 API 호출
    let syncRes = http.get('http://host.docker.internal:5000/api/test');
    console.log(`Sync Response Time: ${syncRes.timings.duration} ms`);

    // 비동기 API 호출
    let asyncRes = http.get('http://host.docker.internal:5000/api/test/A');
    console.log(`Async Response Time: ${asyncRes.timings.duration} ms`);

    sleep(1);
}