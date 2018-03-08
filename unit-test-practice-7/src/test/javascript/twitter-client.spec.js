const TwitterClient = require('../../main/javascript/twitter-client');

describe('TwitterClient', () => {

    let twitter;

    beforeEach(() => {
        twitter = new TwitterClient();
    });

    it('example tests', () => {
        return twitter.tweetSteps(98);
    });

});